using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Serialization
{
    /// <summary>
    /// Controls object and some member level serialization 
    /// </summary>
    public class SymConnectObject : System.Attribute
    {
        internal string _recordName;

        internal string _repgenName;

        internal SymConnectObjectSerialization _serializationType;

        public SymConnectObject(string recordName,
            SymConnectObjectSerialization serializationType = SymConnectObjectSerialization.Implicit)
        {
            _recordName = recordName;
            _serializationType = serializationType;

        }

        public SymConnectObject(string recordName,
            string repgenName,
            SymConnectObjectSerialization serializationType = SymConnectObjectSerialization.Implicit)
        {
            _recordName = recordName;
            _repgenName = repgenName;
            _serializationType = serializationType;
        }
    }


    public enum SymConnectObjectSerialization
    {
        Implicit,
        Explicit
    }
}
