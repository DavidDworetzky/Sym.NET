using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymNet.Core.Extensions;
using SymNet.Core.Serialization;

namespace SymNet.Core.Models.Core
{
    [SymConnectObject("Share", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Share
    {
        [JsonConstructor]
        public Share(string description, string type, string shareId, string activityDate, ShareCode shareCode,
            string checkDigits, IRSCode irsCode,
            int irsPlan,
            Decimal balance,
            Decimal availableBalance,
            Decimal originalBalance,
            Decimal minimumBalance,
            Decimal minimumDeposit,
            Decimal minimumWithdrawal,
            Decimal overdrawTolerance,
            string micrAcctNumber,
            string escrowedLoanId,
            Decimal escrowYtd,
            Decimal escrowLastYear,
            int branch,
            string openDate,
            string closeDate,
            string reference,
            string nickname,
            string lastFmDate,
            string recordChangeDate,
            string lastTranDate,
            string lastPurgeDate,
            string lastDirectDepDate,
            Decimal lastDirectDepAmount,
            string originalDepositDate,
            Decimal originalDeposit,
            MaturityPostCode maturityPostCode,
            string maturityDate,
            TermFrequency termFrequency,
            int termPeriod,
            string renewShareType,
            TermFrequency renewTermFrequency,
            int renewTermPeriod,
            int createdByUser,
            int createdAtBranch,
            int warningCode1,
            int warningCode2,
            int warningCode3,
            int warningCode4,
            int warningCode5,
            int warningCode6,
            int warningCode7,
            int warningCode8,
            int warningCode9,
            int warningCode10,
            int warningCode11,
            int warningCode12,
            int warningCode13,
            int warningCode14,
            int warningCode15,
            int warningCode16,
            int warningCode17,
            int warningCode18,
            int warningCode19,
            int warningCode20,
            string warningExpiration1,
            string warningExpiration2,
            string warningExpiration3,
            string warningExpiration4,
            string warningExpiration5,
            string warningExpiration6,
            string warningExpiration7,
            string warningExpiration8,
            string warningExpiration9,
            string warningExpiration10,
            string warningExpiration11,
            string warningExpiration12,
            string warningExpiration13,
            string warningExpiration14,
            string warningExpiration15,
            string warningExpiration16,
            string warningExpiration17,
            string warningExpiration18,
            string warningExpiration19,
            string warningExpiration20,
            string odtAuthFeeSrcCodeList1,
            string odtAuthFeeSrcCodeList2,
            string odtAuthFeeSrcCodeList3,
            string odtAuthFeeSrcCodeList4,
            int authFeeOption1,
            int authFeeOption2,
            int authFeeOption3,
            int authFeeOption4,
            int authFeeOption5


            )
        {
            Description = description;
            Type = type;
            Id = shareId;
            ActivityDate = activityDate.ParseNullableSymDateString();
            ShareCode = shareCode;
            CheckDigits = checkDigits;
            IRSCode = irsCode;
            IRSPlan = irsPlan;
            Balance = balance;
            AvailableBalance = availableBalance;
            OriginalBalance = originalBalance;
            MinimumBalance = minimumBalance;
            MinimumDeposit = minimumDeposit;
            MinimumWithdrawal = minimumWithdrawal;
            OverdrawTolerance = overdrawTolerance;
            MICRAcctNumber = micrAcctNumber;
            EscrowedLoanId = escrowedLoanId;
            EscrowYTD = escrowYtd;
            EscrowLastYear = escrowLastYear;
            Branch = branch;
            OpenDate = openDate.ParseNullableSymDateString();
            CloseDate = closeDate.ParseNullableSymDateString();
            Reference = reference;
            Nickname = nickname;
            LastFMDate = lastFmDate.ParseNullableSymDateString();
            RecordChangeDate = recordChangeDate.ParseNullableSymDateString();
            LastTranDate = lastTranDate.ParseNullableSymDateString();
            LastPurgeDate = lastPurgeDate.ParseNullableSymDateString();
            LastDirectDepDate = lastDirectDepDate.ParseNullableSymDateString();
            LastDirectDepAmount = lastDirectDepAmount;
            OriginalDepositDate = originalDepositDate.ParseNullableSymDateString();
            OriginalDeposit = originalDeposit;
            MaturityPostCode = maturityPostCode;
            MaturityDate = maturityDate.ParseNullableSymDateString();
            TermFrequency = termFrequency;
            TermPeriod = termPeriod;
            RenewShareType = renewShareType;
            RenewTermFreq = renewTermFrequency;
            RenewTermPeriod = renewTermPeriod;
            CreatedByUser = createdByUser;
            CreatedAtBranch = createdAtBranch;
            Warnings = new List<Warnings>()
            {
                new Warnings(warningCode1, warningExpiration1.ParseNullableSymDateString()),
                new Warnings(warningCode2, warningExpiration2.ParseNullableSymDateString()),
                new Warnings(warningCode3, warningExpiration3.ParseNullableSymDateString()),
                new Warnings(warningCode4, warningExpiration4.ParseNullableSymDateString()),
                new Warnings(warningCode5, warningExpiration5.ParseNullableSymDateString()),
                new Warnings(warningCode6, warningExpiration6.ParseNullableSymDateString()),
                new Warnings(warningCode7, warningExpiration7.ParseNullableSymDateString()),
                new Warnings(warningCode8, warningExpiration8.ParseNullableSymDateString()),
                new Warnings(warningCode9, warningExpiration9.ParseNullableSymDateString()),
                new Warnings(warningCode10, warningExpiration10.ParseNullableSymDateString()),
                new Warnings(warningCode11, warningExpiration11.ParseNullableSymDateString()),
                new Warnings(warningCode12, warningExpiration12.ParseNullableSymDateString()),
                new Warnings(warningCode13, warningExpiration13.ParseNullableSymDateString()),
                new Warnings(warningCode14, warningExpiration14.ParseNullableSymDateString()),
                new Warnings(warningCode15, warningExpiration15.ParseNullableSymDateString()),
                new Warnings(warningCode16, warningExpiration16.ParseNullableSymDateString()),
                new Warnings(warningCode17, warningExpiration17.ParseNullableSymDateString()),
                new Warnings(warningCode18, warningExpiration18.ParseNullableSymDateString()),
                new Warnings(warningCode19, warningExpiration19.ParseNullableSymDateString()),
                new Warnings(warningCode20, warningExpiration20.ParseNullableSymDateString()),
            };
            //odt fee src codes and auth fees - fee settings for RegE
            OdtAuthFeeSrcCodeList1 = odtAuthFeeSrcCodeList1;
            OdtAuthFeeSrcCodeList2 = odtAuthFeeSrcCodeList2;
            OdtAuthFeeSrcCodeList3 = odtAuthFeeSrcCodeList3;
            OdtAuthFeeSrcCodeList4 = odtAuthFeeSrcCodeList4;
            AuthFeeOption1 = authFeeOption1;
            AuthFeeOption2 = authFeeOption2;
            AuthFeeOption3 = authFeeOption3;
            AuthFeeOption4 = authFeeOption4;
        }

        [SymConnectProperty]
        [JsonProperty]
        public string Description { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Type { get; set; }

        [SymConnectProperty("ShareID")]
        [JsonProperty("ShareID")]
        public string Id { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ActivityDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public ShareCode ShareCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CheckDigits { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public IRSCode IRSCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int IRSPlan { get; set; }

        //BALANCE AND TRANSACTION INFORMATION

        [SymConnectProperty]
        [JsonProperty]
        public decimal Balance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal AvailableBalance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal OriginalBalance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal MinimumBalance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal MinimumDeposit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal MinimumWithdrawal { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal OverdrawTolerance { get; set; }

        /// <summary>
        /// MICR account number
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string MICRAcctNumber { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string EscrowedLoanId { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal EscrowYTD { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public decimal EscrowLastYear { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int Branch { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? OpenDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CloseDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Nickname { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastFMDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RecordChangeDate { get; set; }

        /// <summary>
        /// Last Transaction Date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastTranDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastPurgeDate { get; set; }

        /// <summary>
        /// Last Direct Deposit Date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastDirectDepDate { get; set; }

        /// <summary>
        /// Last Direct Deposit Amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public decimal LastDirectDepAmount { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CertificateNumber { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? OriginalDepositDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal OriginalDeposit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public MaturityPostCode MaturityPostCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? MaturityDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TermFrequency TermFrequency { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int TermPeriod { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string RenewShareType { get; set; }

        /// <summary>
        /// Renew term frequency
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public TermFrequency RenewTermFreq { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int RenewTermPeriod { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedByUser { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedAtBranch { get; set; }

        [SymConnectProperty(arraySize: 20)]
        [JsonProperty]
        public IEnumerable<Warnings> Warnings { get; set; }

        //REG E SETTINGS
        [SymConnectProperty]
        [JsonProperty]
        public string OdtAuthFeeSrcCodeList1 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string OdtAuthFeeSrcCodeList2 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string OdtAuthFeeSrcCodeList3 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string OdtAuthFeeSrcCodeList4 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int AuthFeeOption1 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int AuthFeeOption2 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int AuthFeeOption3 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int AuthFeeOption4 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int AuthFeeOption5 { get; set; }

        #region subRecords

        /// <summary>
        /// Tracking sub records
        /// </summary>
        [JsonProperty]
        public List<Tracking> Tracking { get; set; }

        /// <summary>
        /// Hold sub records
        /// </summary>
        [JsonProperty]
        public List<Hold> Holds { get; set; }

        /// <summary>
        /// Name sub records
        /// </summary>
        public List<Name> Names { get; set; }
        #endregion

    }

    public enum ShareCode
    {
        Certificate,
        Club,
        Draft,
        Share
    }

    public enum IRSCode
    {
        [Description("401k")]
        Four01k,
        ArcherMSA,
        ConduitIRA,
        CoverdellESA,
        DeferredComp,
        FamilyHSA,
        Governmental457,
        IRA,
        Keogh,
        MedicareMSA,
        Normal,
        RothConversion,
        RothIRA,
        SEP,
        SimpleIRA,
        SimpleHSA
    }

    public enum MaturityPostCode
    {
        ByCheck,
        Renew,
        Suspend,
        Transfer,
        TransferAndRenew
    }

    public enum TermFrequency
    {
        Days,
        Months
    }
}
