using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Models
{
    /// <summary>
    /// Translation of symserver status to port status DTO
    /// </summary>
    public class PortStatus
    {
        public PortStatus(string ip, string portNumber, PortStatusType status)
        {
            IP = ip;
            PortNumber = portNumber;
            Status = status;
        }

        public string IP { get; set; }
        public string PortNumber { get; set; }
        public PortStatusType Status { get; set; }
    }


    public enum PortStatusType
    {
        active,
        idle,
        failed
    }
}
