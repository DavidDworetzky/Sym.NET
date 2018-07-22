using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymNet.Core.Serialization;
using SymNet.Core.SymConnectMessage;

namespace SymNet.Core.Extensions
{
    public static class RecordPathExtensions
    {
        public static RecordPath Merge(this RecordPath recordPath, RecordPath otherPath)
        {
            List<SymConnectRequestMessage.RecordDesignation> mergedPath = new List<SymConnectRequestMessage.RecordDesignation>();

            mergedPath.AddRange(recordPath.Path);
            mergedPath.AddRange(otherPath.Path);
            return new RecordPath(mergedPath);
        }

        public static RecordPath Reverse(this RecordPath recordPath)
        {
            var newPath = recordPath.Path.Reverse().ToList();
            return new RecordPath(newPath);
        }
    }
}
