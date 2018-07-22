using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymNet.Core.Extensions;
using SymNet.Core.Serialization;

namespace SymNet.Core.Models.Core
{
    [SymConnectObject("Comment", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Comment
    {
        [JsonConstructor]
        public Comment(CommentType commentType, string content, string effectiveDate, string expirationDate, string recordChangeDate, int locator)
        {
            Type = commentType;
            Content = content;
            EffectiveDate = effectiveDate.ParseNullableSymDateString();
            ExpirationDate = expirationDate.ParseNullableSymDateString();
            RecordChangeDate = recordChangeDate.ParseNullableSymDateString();
            Locator = locator;
        }
        [SymConnectProperty]
        [JsonProperty]
        public int Locator { get; set; }

        [SymConnectProperty("CommentType")]
        [JsonProperty("CommentType")]
        public CommentType Type { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        [SymConnectProperty("Comment")]
        [JsonProperty("Comment")]
        public string Content { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? EffectiveDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ExpirationDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RecordChangeDate { get; set; }
    }

    public enum CommentType
    {
        DisplayEveryAccess,
        InquiryOnly,
        TickerReport,
        TickerReportAndForceDisplay
    }
}
