using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using SymNet.Core.Models;

namespace SymNet.Core.Network
{
    /// <summary>
    /// SymConnectTcpManager manages symconnect messages and request pooling
    /// </summary>
    public sealed class SymConnectTcpManager : ISymConnectConnectionManager
    {

        private static ILog _log = log4net.LogManager.GetLogger(typeof(SymConnectTcpManager));

        private List<SymServer> _serverList;
        private readonly List<SymTcpClient> _symConnectionList = new List<SymTcpClient>();

        private int _maxbuffersize;
        private int _maxRetries;
        private int _retryInterval;
        private readonly int _faultedHostReconnectInterval;
        private readonly int _messageSendTimeout;
        private IEnumerable<SymServerConfig> _symServerConfig;

        private readonly object _acquireSocketLock = new object();


        public SymConnectTcpManager(IEnumerable<SymServerConfig> symServerConfig, int maxBufferSize, int maxRetries, int retryInterval, int faultedHostReconnectInterval, int messageSendTimeoutSeconds)
        {
            _symServerConfig = symServerConfig;
            _maxbuffersize = maxBufferSize;
            _maxRetries = maxRetries;
            _retryInterval = retryInterval;
            _faultedHostReconnectInterval = faultedHostReconnectInterval;
            _messageSendTimeout = messageSendTimeoutSeconds;

            InitializeSockets();

            if (faultedHostReconnectInterval > 0)
            {
                InitializedFailedHostRestartTimer();
            }
        }

        public IEnumerable<PortStatus> PortStatus
        {
            get
            {
                return _serverList.Select(server =>
                    new PortStatus(server.Host, server.Port.ToString(),
                        server.IsInUse && !server.IsFaulted
                            ? PortStatusType.active
                            : server.IsFaulted ? PortStatusType.failed : PortStatusType.idle));
            }
        }

        public SymConnectConfiguration SymConnectConfiguration
        {
            set
            {
                WaitRestartHosts(() =>
                {
                    _maxbuffersize = value.MaxBufferSize;
                    _maxRetries = value.MaxRetries;
                    _retryInterval = value.RetryIntervalSeconds;
                    _symServerConfig = value.Config;
                });
            }
        }

        /// <summary>
        /// Socket / tcp initialization method 
        /// </summary>
        private void InitializeSockets()
        {
            lock (_acquireSocketLock)
            {
                _serverList = new List<SymServer>();

                System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Got hosts from config.");

                //initialize sym servers from server config
                var i = 0;
                foreach (var svr in _symServerConfig)
                {
                    _serverList.Add(new SymServer
                    {
                        Id = i,
                        Host = svr.Ip,
                        Port = svr.Port,
                        IsInUse = false,
                        RgSession = svr.RgSession
                    });
                    i++;
                }
                //validate that there are no duplicate hosts
                var duplicates =
                    _serverList.GroupBy(element => new KeyValuePair<string, int>(element.Host, element.Port));

                if (duplicates.Any(element => element.Count() > 1))
                {
                    throw new System.InvalidOperationException(
                        "Cannot instantiate a symconnect tcp manager with duplicate host/port configurations");
                }

                //open sockets for these servers
                OpenSocketsForServers(_serverList);
            }
        }

        /// <summary>
        /// Opens a tcp client connection for a list of symitar servers
        /// </summary>
        /// <param name="serverList"></param>
        private void OpenSocketsForServers(IEnumerable<SymServer> serverList)
        {
            //make sure that there are no matching symconnect tcp clients already with matching IDs

            var symTcpClientList =
                _symConnectionList.Where(connection => serverList.Any(server => connection.Id == server.Id)).ToList();
            if (symTcpClientList.Count > 0)
            {
                throw new Exception(
                    "Found matching tcp clients. Can't re-open existing connections until they have been closed and disposed");
            }

            //now open tcp connections

            foreach (var srv in serverList)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Opening " + srv.Host + ":" + srv.Port);

                    // create the client
                    _symConnectionList.Add(new SymTcpClient
                    {
                        Id = srv.Id,
                        TcpClient = new TcpClient(srv.Host, srv.Port)
                    });

                    System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Success.");
                    _serverList.Single(server => server.Id == srv.Id).IsFaulted = false;
                }
                catch (SocketException s)
                {
                    if (s.ErrorCode == 10061) // refused; connection not open or in use
                    {
                        // fault connection if we receive a 10061 error
                        _serverList.Single(server => server.Id == srv.Id).IsFaulted = true;
                        System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: SocketException 10061.");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Exception - " + s.Message);
                        throw;
                    }
                }
            }
        }

        private void CloseSocketsForServers(IEnumerable<SymServer> serverList)
        {
            var clientList =
                _symConnectionList.Where(connection => serverList.Any(server => connection.Id == server.Id)).ToList();

            //close client sockets
            foreach (var client in clientList)
            {
                //we have to close the stream and dispose of the client to properly close our TCP connection
                client.TcpClient.GetStream().Close();
                client.TcpClient.Dispose();
            }
            //remove clients
            _symConnectionList.RemoveAll(client => clientList.Any(cl => cl.Id == client.Id));

            //mark servers as not in use
            foreach (var server in serverList)
            {
                server.IsInUse = false;
            }
        }

        private SymServer GetNextHost()
        {
            var server = _serverList.Find(srv => srv.IsUseable);

            // lock server
            if (server == null)
                return null;

            server.IsInUse = true;
            return server;
        }

        private void UnlockHost(SymServer host)
        {
            // unlock server
            host.IsInUse = false;
        }


        /// <summary>
        /// Asyncronously fetch our next symServer from the list
        /// </summary>
        /// <returns></returns>
        private async Task<SymServer> AcquireNextHost()
        {
            int attempts = 0;
            //set a task completion source and a timer, attempt to re-acquire our socket every 
            TaskCompletionSource<SymServer> tcs = null;
            SymServer acquiredServer = null;
            //set timer for retry interval on send
            var t = new System.Timers.Timer() { AutoReset = true, Enabled = true, Interval = _retryInterval };
            //create task completion source loop
            tcs = new TaskCompletionSource<SymServer>(t);
            t.Elapsed += (sender, e) =>
            {
                var senderTimer = sender as System.Timers.Timer;
                lock (_acquireSocketLock)
                {
                    acquiredServer = GetNextHost();
                }
                attempts++;

                if (acquiredServer != null || attempts > _maxRetries)
                {
                    senderTimer.Close();
                    if (!tcs.TrySetResult(acquiredServer))
                    {
                        System.Diagnostics.Debug.WriteLine("Failed to set result for host acquisition");
                    }
                }
            };
            //activate our timer
            t.Start();
            //await our task result
            return await tcs.Task;
        }

        /// <summary>
        /// Initializes a timer that occasionally attempts to restart failed symconnect ports.
        /// </summary>
        public void InitializedFailedHostRestartTimer()
        {
            var t = new System.Timers.Timer() { AutoReset = true, Enabled = true, Interval = _faultedHostReconnectInterval };
            t.Elapsed += (sender, e) =>
            {
                RestartFailedHosts();
            };
        }

        /// <summary>
        /// Restarts all sym servers, after waiting for hosts to stop
        /// </summary>
        /// <param name="restartAction"></param>
        public void WaitRestartHosts(Action restartAction)
        {
            //stop all other threads from acquiring sockets while we are re-starting our hosts
            lock (_acquireSocketLock)
            {
                //if all hosts aren't stopped, wait our thread sleep interval to stop them
                int attempts = 0;
                //sleep this thread x times syncronously waiting for stop
                bool allHostsStopped = !_serverList.Exists(srvr => srvr.IsInUse);
                while (!allHostsStopped || attempts > _maxRetries)
                {
                    Thread.Sleep(_retryInterval);
                    allHostsStopped = !_serverList.Exists(srvr => srvr.IsInUse);
                    attempts++;
                }
                //close all connections and remove all clients
                foreach (var client in _symConnectionList)
                {
                    client.TcpClient.GetStream().Close();
                    client.TcpClient.Dispose();
                }
                _symConnectionList.RemoveAll(srvr => true);
                _serverList.RemoveAll(srvr => true);

                restartAction();

                //now re-initialize ports 

                InitializeSockets();
            }
        }

        /// <summary>
        /// Restarts specific hosts given a filter, with no wait 
        /// </summary>
        /// <param name="restartAction"></param>
        /// <param name="symServerFilter"></param>
        public void ForceRestartSpecificHosts(Action restartAction = null, Func<SymServer, bool> symServerFilter = null)
        {
            //stop all other threads from acquiring sockets while we are re-starting our hosts
            lock (_acquireSocketLock)
            {
                //get our sym server list according to our filter
                var symServerList = symServerFilter != null ? _serverList.Where(symServerFilter) : _serverList;

                //now, dispose of our tcp client connections, and attempt to re-open these faulted sockets
                CloseSocketsForServers(symServerList);
                OpenSocketsForServers(symServerList);
            }
        }
        /// <summary>
        /// Restarts all faulted TCP connections
        /// </summary>
        public void RestartFailedHosts()
        {
            ForceRestartSpecificHosts(symServerFilter: (symServer) => symServer.IsFaulted);
        }

        /// <summary>
        /// Can either take a direct request, or an rgMessageParameterizedGenerator to generate an RG call parameterized by our SymServer's RGSESSION
        /// </summary>
        /// <param name="requestMessage">a direct symconnect message rqeuest</param>
        /// <param name="rgMessageParameterizedGenerator">a request parameterized by our RGSESSION</param>
        /// <returns></returns>
        public async Task<string> SendSymMessage(string requestMessage = null, Func<int, string> rgMessageParameterizedGenerator = null)
        {
            if (requestMessage == null && rgMessageParameterizedGenerator == null)
            {
                throw new Exception("Cannot make a symconnect call without either a direct or a parameterized request");
            }

            if (requestMessage != null && rgMessageParameterizedGenerator != null)
            {
                throw new Exception("Cannot pass in both a direct request and an RG parameterized request");
            }
            string response;

            //acquire host and throw an exception if we could not acquire one in time.
            var server = await AcquireNextHost();
            if (server == null)
            {
                _log.Info("SymConnectTcpManager: No connections available.");
                System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: No connections available.");
                throw new Exception(
                    $"Could not acquire a socket in time. Exceeded {_maxRetries} retries with interval of {_retryInterval} milliseconds"); // no connections available
            }

            //after acquiring our next symconnect host, 
            try
            {
                //our message is either the direct request message, or the parameterized generator's result
                string message = requestMessage ?? rgMessageParameterizedGenerator(server.RgSession);

                _log.Info("SymConnectTcpManager: Request - " + message);
                System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Request - " + message);

                message += "\n"; //required or Symitar will ignore the message

                // The ID of the server was being used to identify the location of the SymConnection in the list; so if the server ID is 
                // the 2nd one (1 since it is a zero-based array) but the list only has 1 valid item in the collection since the collection 
                // is dependent on how many open items are in the list, it will attempt to accepts the SymConnection based on its position 
                // in the List --> which can create an ArrayOutOfBounds exception
                //var client = _symConnectionList[server.Id];
                var client = _symConnectionList.Find(symConn => symConn.Id == server.Id).TcpClient;

                // open if not already open
                if (!client.Connected)
                {
                    _log.Info("SymConnectTcpManager: Reopening port.");
                    System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Reopening port.");
                    client.Connect(server.Host, server.Port);
                }


                // send message
                _log.Info("SymConnectTcpManager: Sending message");
                System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Sending message.");
                var socket = client.Client;
                socket.Send(Encoding.ASCII.GetBytes(message));
                _log.Info("SymConnectTcpManager: Sending message");
                System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Sent.");

                // get response line(s)
                bool timedOut = false;

                //start a timer for message receipt
                var messageTimer = new System.Timers.Timer()
                {
                    AutoReset = false,
                    Enabled = true,
                    Interval = _messageSendTimeout
                };
                messageTimer.Elapsed += ((sender, e) => { timedOut = true; });
                messageTimer.Start();
#if DEBUG
                var watch = new Stopwatch();
                watch.Start();
#endif

                //create a network stream to read our response
                NetworkStream networkStream = new NetworkStream(socket);

                StreamReader reader = new StreamReader(networkStream);
                //each message is delimited by a newline
                response = await reader.ReadLineAsync();
                //stop the timer
                messageTimer.Stop();
#if DEBUG
                watch.Stop();

                System.Diagnostics.Debug.WriteLine($"SymConnectTcpManager: Message took {watch.ElapsedMilliseconds} milliseconds to return from symitar");
#endif
                //trim nulls from string
                response = response.Replace("\0", "");
                if (timedOut)
                {
                    throw new Exception($"Send symconnect message timed out after {_messageSendTimeout} milliseconds");
                }
                // unlock port
                UnlockHost(server);
            }
            catch (SocketException ex)
            {
                System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Exception - " + ex.Message);
                // If port fails with socket exception, mark port as faulted
                server.IsFaulted = true;
                throw;
            }
            finally
            {
                //but always unlock the host for future use
                UnlockHost(server);
            }

            // response
            string responseMessage = response.Replace("\n", "");
            _log.Info("SymConnectTcpManager: Response - " + responseMessage);
            System.Diagnostics.Debug.WriteLine("SymConnectTcpManager: Response - " + responseMessage);

            return responseMessage;
        }

        private bool HandshakeServer(SymServer symServer)
        {
            try
            {
                if (symServer == null)
                    return false;

                symServer.IsInUse = true;

                //var client = _symConnectionList[symServer.Id];
                var client = _symConnectionList.Find(symConn => symConn.Id == symServer.Id).TcpClient;

                // open if not already open
                if (!client.Connected)
                    client.Connect(symServer.Host, symServer.Port);

                // send/rcv buffers
                var req = Encoding.ASCII.GetBytes("HANDSHAKE\n");
                var resp = new byte[_maxbuffersize];

                // send handshake
                var socket = client.Client;
                socket.Send(req);

                // get & validate response
                socket.Receive(resp);
                var handshakeResponse = Encoding.ASCII.GetString(resp).Replace("\0", "").Replace("\n", "").Trim(); //trim nulls and control chars;

                if (handshakeResponse.StartsWith("RSHANDSHAKE"))
                {
                    // good response
                    symServer.IsInUse = false;
                    return true;
                }

                // bad response; leave host out of pool
                return false;
            }
            catch (SocketException s)
            {
                if (s.ErrorCode == 10061) // refused; connection not open or in use
                {
                    // take server out of rotation
                    symServer.IsFaulted = true;
                    return false;
                }

                // take server out of rotation
                symServer.IsFaulted = true;
                return false;
            }
        }

        public bool HandshakeAllPorts()
        {
            return _serverList.Select(HandshakeServer).All(handShakeSuccess => handShakeSuccess);
        }
    }
}
