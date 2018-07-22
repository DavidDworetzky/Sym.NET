using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymNet.Core.SymConnectMessage;

namespace SymNet.Core.Serialization
{
    /// <summary>
    /// Record path object
    /// </summary>
    public class RecordPath
    {
        public RecordPath(IList<SymConnectRequestMessage.RecordDesignation> path)
        {
            Path = path;
        }

        /// <summary>
        /// Record path designation
        /// </summary>
        public IList<SymConnectRequestMessage.RecordDesignation> Path { get; set; }
    }
}
