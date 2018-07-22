using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.SymConnectMessage
{
    [System.Flags]
    public enum SymConnectMessageType
    {
        //Repgen
        RG,
        //Inquiry
        IQ,
        //File Maintenance
        FM,
        //Transaction
        TR,
        //Administrative
        AD
    }
}
