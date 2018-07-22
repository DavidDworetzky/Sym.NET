using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Network
{
    /// <summary>
    /// Data type used to initialize our list of Sym Server in SymConnectTcpManager
    /// </summary>
    public class SymServerConfig
    {
        public SymServerConfig(int port, string ip, int rgSession)
        {
            Port = port;
            Ip = ip;
            RgSession = rgSession;
        }

        public int Port { get; set; }

        public string Ip { get; set; }

        public int RgSession { get; set; }
    }
}
