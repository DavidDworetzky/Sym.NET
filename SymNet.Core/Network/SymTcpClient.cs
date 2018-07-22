using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Network
{
    internal class SymTcpClient
    {
        public int Id { get; set; }
        public TcpClient TcpClient { get; set; }
    }
}
