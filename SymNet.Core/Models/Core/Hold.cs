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
    [SymConnectObject("Hold", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Hold
    {
        [JsonConstructor]
        public Hold(HoldType holdType, RecurringStop achRecurringStop, string effectiveDate, string expirationDate,
            string expirationTime, string recordChangeDate,
            string matchDate,
            string matchTime,
            string transactionType,
            string feeCode,
            Decimal holdAmount,
            string reference1,
            string reference2,
            string reference3,
            string payeeName,
            string memberBranch,
            string stopReasonCode,
            string reference4,
            int locator)
        {
            Type = holdType;
            ACHRecurringStop = achRecurringStop;
            EffectiveDate = effectiveDate.ParseNullableSymDateString();
            ExpirationDate = expirationDate.ParseNullableSymDateString();
            ExpirationTime = expirationTime.ParseNullableSymHoursAndMinutesString();
            RecordChangeDate = recordChangeDate.ParseNullableSymDateString();
            MatchDate = matchDate.ParseNullableSymDateString();
            MatchTime = matchTime.ParseNullableSymHoursAndMinutesString();
            TransactionType = transactionType;
            FeeCode = feeCode;
            HoldAmount = holdAmount;
            Reference1 = reference1;
            Reference2 = reference2;
            Reference3 = reference3;
            PayeeName = payeeName;
            MemberBranch = memberBranch;
            StopReasonCode = stopReasonCode;
            Reference4 = reference4;
            Locator = locator;
        }
        [SymConnectProperty]
        [JsonProperty]
        public int Locator { get; set; }

        [SymConnectProperty("HoldType")]
        [JsonProperty("HoldType")]
        public HoldType Type { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public RecurringStop ACHRecurringStop { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? EffectiveDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ExpirationDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TimeSpan? ExpirationTime { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RecordChangeDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? MatchDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TimeSpan? MatchTime { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string TransactionType { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string FeeCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal HoldAmount { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference1 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference2 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string PayeeName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string MemberBranch { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string StopReasonCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference3 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference4 { get; set; }

    }

    public enum HoldType
    {
        ACHDNE,
        ACHOrigination,
        BillPayment,
        BillPaymentInformation,
        BusinessBlockACHDebit,
        CertifiedDraft,
        CheckHold,
        GeneralPurpose,
        LoanDraft,
        MerchantVerification,
        MerchantVerificationInformation,
        PINAuth,
        PledgeHold,
        RevokeACH,
        SignatureAuth,
        StopACH,
        StopACHVerbal,
        StopDraft,
        StopDraftVerbal,
        UnauthorizedACHStop,
        UncollectedFee,
        Wire
    }

    public enum RecurringStop
    {
        SingleStop,
        RecurringStop
    }
}
