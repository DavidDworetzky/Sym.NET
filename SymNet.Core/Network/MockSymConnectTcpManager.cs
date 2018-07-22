using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SymNet.Core.Models;

namespace SymNet.Core.Network
{
    public class MockSymConnectTcpManager : ISymConnectConnectionManager
    {
        private static ILog _log = log4net.LogManager.GetLogger(typeof(MockSymConnectTcpManager));
        public Task<string> SendSymMessage(string requestMessage = null, Func<int, string> rgMessageParameterizedGenerator = null)
        {
            if (requestMessage != null)
            {
                _log.Info($"Mock Tcp Manager would have sent message:{requestMessage}");
            }
            else if (rgMessageParameterizedGenerator != null)
            {
                //100 is the arbitrary port we would have used
                _log.Info($"Mock Tcp Manager would have sent message:{rgMessageParameterizedGenerator(100)}");
            }
            else
            {
                throw new System.Exception("Cannot send null request message to symitar");
            }
            //mock providers return no responses :)
            return Task.FromResult(String.Empty);
        }

        public SymConnectConfiguration SymConnectConfiguration { get; set; }
        public void ForceRestartSpecificHosts(Action restartAction = null, Func<SymServer, bool> symServerFilter = null)
        {
            //do nothing, we have no hosts to restart
        }

        /// <summary>
        /// Returns port status upstream
        /// </summary>
        public IEnumerable<PortStatus> PortStatus => new List<PortStatus>();
    }
}
