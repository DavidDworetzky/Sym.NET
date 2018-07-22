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
    [SymConnectObject("Card", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Card
    {
        [JsonConstructor]
        public Card(string type, string description, string number, CardStatus status, string suffix,
            string statusReason, int createdByUser, int createdAtBranch,
            string issueDate,
            string effectiveDate,
            string expirationDate,
            string activeDate,
            string closeDate,
            string extraEmboss,
            string lastAddrChgDate,
            string recordChangeDate,
            int issueCode,
            int reissueCode,
            int reissueMonths,
            int instantIssue,
            int pinActual,
            int pinOffset,
            int pinRetries,
            string pinOrderDate,
            int locator
            )
        {
            Type = type;
            Description = description;
            Number = number;
            Status = status;
            Suffix = suffix;
            StatusReason = statusReason;
            CreatedByUser = createdByUser;
            CreatedAtBranch = createdAtBranch;
            IssueDate = issueDate.ParseNullableSymDateString();
            EffectiveDate = effectiveDate.ParseNullableSymDateString();
            ExpirationDate = expirationDate.ParseNullableSymDateString();
            ActiveDate = activeDate.ParseNullableSymDateString();
            CloseDate = closeDate.ParseNullableSymDateString();
            ExtraEmboss = extraEmboss;
            LastAddrChgDate = lastAddrChgDate.ParseNullableSymDateString();
            RecordChangeDate = recordChangeDate.ParseNullableSymDateString();
            IssueCode = issueCode;
            ReissueCode = reissueCode;
            ReissueMonths = reissueMonths;
            InstantIssue = instantIssue;
            PINActual = pinActual;
            PINOffset = pinOffset;
            PINRetries = pinRetries;
            PINOrderDate = pinOrderDate.ParseNullableSymDateString();
            Locator = locator;
        }

        [SymConnectProperty]
        [JsonProperty]
        public int Locator { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Type { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// Card number
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string Number { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public CardStatus Status { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Suffix { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string StatusReason { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedByUser { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedAtBranch { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? IssueDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? EffectiveDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Activation Date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ActiveDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// Extra emboss line
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string ExtraEmboss { get; set; }

        /// <summary>
        /// Last address change date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastAddrChgDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RecordChangeDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int IssueCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int ReissueCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int ReissueMonths { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int InstantIssue { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int PINActual { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int PINOffset { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int PINRetries { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? PINOrderDate { get; set; }

        #region subRecords

        /// <summary>
        /// Name sub records
        /// </summary>
        [JsonProperty]
        public List<Name> Names { get; set; }
        #endregion
    }

    public enum CardStatus
    {
        Captured,
        Issued,
        NotIssued
    }

    public enum NameType
    {
        FirstJointNameAndAddress,
        PrimaryNameAndAddress,
        SeparateCardNameAndAddress,
    }
}
