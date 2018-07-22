using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Network
{
    public class SymServer
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public int RgSession { get; set; }

        public bool IsUseable
        {
            get { return !IsFaulted && !IsInUse; }
        }

        public bool IsInUse { get; set; }

        public bool IsFaulted { get; set; }

    }
}
