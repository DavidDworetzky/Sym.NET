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
    [SymConnectObject("Account", "US.ACCOUNTS", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Account
    {
        [JsonConstructor]
        public Account(string number, int branch, int type, int memberGroup, string openDate,
            string lastFmDate,
            string recordChangeDate,
            string activityDate,
            string pRGDRECACTIVITYDT,
            string cORRESPONDDATE,
            string proxyDate,
            string closeDate,
            string fmLastPurgeDate,
            string reference,
            MembershipStatus memberStatus,
            CommercialCode commercialCode,
            decimal krHoldBaseAmount,
            decimal checkDepTotalAmount,
            string krTotalDate,
            decimal nonRegCCCheckHoldBaseAmt,
            decimal nonRegCCCheckTotalAmt,
            int currentRelationshipCode,
            RelationshipCode relationshipCode,
            string relationshipOverrideEffDate,
            string relationshipOverride,
            string relationshipOverrideExpDate,
            string householdAccount,
            HouseholdStatement householdStatement,
            StatementMailCode statementMailCode,
            EStatementEmailNotify eStmtNotify,
            EStatementEnable eStmtEnable,
            string stateReporting,
            int createdByUser,
            int createdAtBranch,
            decimal cRTotalAmount,
            decimal cDTotalAmount,
            decimal fRCRTotalAmount,
            decimal fRCDTotalAmount,
            decimal fRCDUnits,
            decimal wRTotalAmount,
            decimal wDTotalAmount,
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
            string warningExpiration20

            )
        {
            Number = number;
            Branch = branch;
            Type = type;
            MemberGroup = memberGroup;
            OpenDate = openDate.ParseNullableSymDateString();
            LastFMDate = lastFmDate.ParseNullableSymDateString();
            RecordChangeDate = recordChangeDate.ParseNullableSymDateString();
            LastActivityDate = activityDate.ParseNullableSymDateString();
            PRGDRECACTIVITYDT = pRGDRECACTIVITYDT.ParseNullableSymDateString();
            CORRESPONDDATE = cORRESPONDDATE.ParseNullableSymDateString();
            ProxyDate = proxyDate.ParseNullableSymDateString();
            CloseDate = closeDate.ParseNullableSymDateString();
            FMLastPurgeDate = fmLastPurgeDate.ParseNullableSymDateString();
            Reference = reference;
            MemberStatus = memberStatus;
            CommercialCode = commercialCode;
            KRHoldBaseAmount = krHoldBaseAmount;
            CheckDepositTotalAmount = checkDepTotalAmount;
            KRTotalDate = krTotalDate.ParseNullableSymDateString();
            NonRegCCCheckHoldBaseAmt = nonRegCCCheckHoldBaseAmt;
            NonRegCCCheckTotalAmt = nonRegCCCheckTotalAmt;
            CurrentRelationshipCode = currentRelationshipCode;
            RelationshipCode = relationshipCode;
            RelationshipOverrideEffectiveDate = relationshipOverrideEffDate.ParseNullableSymDateString();
            RelationshipOverride = relationshipOverride;
            RelationshipOverrideEffectiveDate = relationshipOverrideEffDate.ParseNullableSymDateString();
            RelationshipOverrideExpirationDate = relationshipOverrideExpDate.ParseNullableSymDateString();
            HouseholdAccount = householdAccount;
            HouseholdStatement = householdStatement;
            StatementMailCode = statementMailCode;
            EStmtNotify = eStmtNotify;
            EStmtEnable = eStmtEnable;
            StateReporting = stateReporting;
            CreatedByUser = createdByUser;
            CreatedAtBranch = createdAtBranch;
            CRTotalAmount = cRTotalAmount;
            CDTotalAmount = cDTotalAmount;
            FRCRTotalAmount = fRCRTotalAmount;
            FRCDTotalAmount = fRCDTotalAmount;
            FRCDUnits = fRCDUnits;
            WRTotalAmount = wRTotalAmount;
            WDTotalAmount = wDTotalAmount;
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
        }


        /// <summary>
        /// Accountnumber
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string Number { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int Branch { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public int Type { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int MemberGroup { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? OpenDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastFMDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RecordChangeDate { get; set; }

        [SymConnectProperty("ActivityDate")]
        [JsonProperty("ActivityDate")]
        public DateTime? LastActivityDate { get; set; }

        /// <summary>
        /// Purged record activity date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? PRGDRECACTIVITYDT { get; set; }

        /// <summary>
        /// Correspondence date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CORRESPONDDATE { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ProxyDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// File maintenance history last purge date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? FMLastPurgeDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference { get; set; }

        /// <summary>
        /// Membership Status
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public MembershipStatus MemberStatus { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public CommercialCode CommercialCode { get; set; }

        /// <summary>
        /// Check hold base amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal KRHoldBaseAmount { get; set; }

        [SymConnectProperty("CheckDepTotalAmount")]
        [JsonProperty("CheckDepTotalAmount")]
        public Decimal CheckDepositTotalAmount { get; set; }

        /// <summary>
        /// Check deposit total date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? KRTotalDate { get; set; }

        /// <summary>
        /// Non regular CC check hold base amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal NonRegCCCheckHoldBaseAmt { get; set; }

        /// <summary>
        /// Non regular CC check hold total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal NonRegCCCheckTotalAmt { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CurrentRelationshipCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public RelationshipCode RelationshipCode { get; set; }

        [SymConnectProperty("RelationshipOverrideEffDate")]
        [JsonProperty("RelationshipOverrideEffDate")]
        public DateTime? RelationshipOverrideEffectiveDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string RelationshipOverride { get; set; }

        [SymConnectProperty("RelationshipOverrideExpDate")]
        [JsonProperty("RelationshipOverrideExpDate")]
        public DateTime? RelationshipOverrideExpirationDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string HouseholdAccount { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public HouseholdStatement HouseholdStatement { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public StatementMailCode StatementMailCode { get; set; }

        /// <summary>
        /// Estatement email notify
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public EStatementEmailNotify EStmtNotify { get; set; }

        /// <summary>
        /// Estatement enable
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public EStatementEnable EStmtEnable { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string StateReporting { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedByUser { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedAtBranch { get; set; }

        /// <summary>
        /// US cash received total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal CRTotalAmount { get; set; }

        /// <summary>
        /// US cash disbursed total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal CDTotalAmount { get; set; }

        /// <summary>
        /// Foreign cash received total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal FRCRTotalAmount { get; set; }

        /// <summary>
        /// Foreign cash disbursed total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal FRCDTotalAmount { get; set; }

        /// <summary>
        /// Foreign cash received units
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal FRCRUnits { get; set; }

        /// <summary>
        /// Foreign cash disbursed units
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal FRCDUnits { get; set; }

        /// <summary>
        /// Wire received total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal WRTotalAmount { get; set; }

        /// <summary>
        /// Wire disbursed total amount
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public Decimal WDTotalAmount { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public List<Warnings> Warnings { get; set; }

        #region subRecords


        /// <summary>
        /// Share sub records
        /// </summary>
        [JsonProperty]
        public List<Share> Shares { get; set; }

        /// <summary>
        /// Name sub records
        /// </summary>
        [JsonProperty]
        public List<Name> Names { get; set; }

        /// <summary>
        /// Loan sub records
        /// </summary>
        [JsonProperty]
        public List<Loan> Loans { get; set; }

        /// <summary>
        /// Tracking sub records
        /// </summary>
        [JsonProperty]
        public List<Tracking> Tracking { get; set; }

        /// <summary>
        /// Card sub records
        /// </summary>
        [JsonProperty]
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Credit report sub records
        /// </summary>
        [JsonProperty]
        public List<CreditReport> CreditReports { get; set; }



        #endregion
    }

    public enum AccountType
    {
        BoardMember,
        Business,
        EducationLoan,
        Employee,
        EmployeeFamily,
        Estate,
        GeneralMembership,
        Organization,
        POD_FBO,
        SoleProprietorship,
        Trust,
        Tutma
    }
    public enum RestrictedAccess
    {
        Employee,
        EmployeeFamily,
        EmployeeSensitive,
        EmployeeSensitiveFamily,
        Normal,
        Restricted,
        Sensitive
    }

    public enum MembershipStatus
    {
        NaturalPerson,
        NonMember
    }

    public enum CommercialCode
    {
        Commercial,
        Consumer,
        SmallBusiness
    }

    public enum RelationshipCode
    {
        Business,
        Free,
        General,
        Plus,
        Premium,
        Prepaid,
        Teen
    }

    public enum HeadOfHousehold
    {
        HeadOfHousehold,
        OtherFamilyMember
    }

    public enum HouseholdStatement
    {
        DoNotConsolidate,
        GroupWithHeadOfHousehold
    }

    public enum StatementMailCode
    {
        BadAddress,
        BadAddressNoMail,
        NoMail,
        UseIndividualMailCodes,

    }

    public enum EStatementEmailNotify
    {
        NoEmail,
        Email
    }

    public enum EStatementEnable
    {
        EnableBoth,
        EnableEStatementOnly,
        EStatementNotEnabled
    }
}
