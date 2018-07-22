using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymNet.Core.Serialization;

namespace SymNet.Core.Models.Core
{
    [SymConnectObject("Note")]
    [JsonObject]
    public class Note
    {

        [SymConnectProperty("Id")]
        [JsonProperty("Id")]
        public int Id { get; set; }
        [SymConnectProperty("TextLine1")]
        [JsonProperty("TextLine1")]
        public string Text { get; set; }
    }
}
