using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymNet.Core.Serialization;

namespace SymNet.Core.Models.Core
{
    [SymConnectObject("Warning", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Warnings
    {
        [JsonConstructor]
        public Warnings(int warningCode, DateTime? warningExpiration)
        {
            Warning = warningCode;
            WarningExpiration = warningExpiration;
        }

        [SymConnectProperty("WarningCode{0}", isTemplate: true)]
        [JsonProperty]
        public int Warning { get; set; }

        [SymConnectProperty("WarningExpiration{0}", isTemplate: true)]
        [JsonProperty]
        public DateTime? WarningExpiration { get; set; }
    }
}
