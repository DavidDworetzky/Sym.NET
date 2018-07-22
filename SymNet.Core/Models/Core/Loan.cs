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
    [SymConnectObject("Loan", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Loan
    {
        [JsonConstructor]
        public Loan(string description, string loanType, string loanId, LoanCode loanCode, string activityDate,
            string checkDigits, string reference,
            string nickname,
            int branch,
            int createdByUser,
            int createdAtBranch,
            int loanPurpose,
            CouponCode couponCode,
            string vinNumber,
            string mFOELId,
            string noteNumber,
            string micrAccountNumber,
            Decimal loanBalance,
            Decimal originalBalance,
            Decimal creditLimit,
            Decimal availableCredit,
            Decimal cashAdvanceLimit,
            Decimal availableCashAdvance,
            Decimal balanceTransferLimit,
            Decimal availableBalanceTransfer,
            Decimal combinedCABTLimit,
            Decimal availableCombinedCABT,
            string creditLimitExpiration,
            AvailableCreditCalculationType availableCreditCalculation,
            int creditLimitGroup,
            Decimal amountAdvanced,
            string lastAdvanceDate,
            string lastPaymentDate,
            string firstPaymentDate,
            PaymentType paymentType,
            PaymentMethod paymentMethod,
            PaymentFrequency paymentFrequency,
            string originalLoanDate,
            string openDate,
            string closeDate,
            Decimal payment,
            Decimal alternatePayment,
            string alternatePmtEffective,
            string alternatePmtExpiration,
            Decimal partialPayment,
            Decimal unappliedPartialPayment,
            Decimal stmtUnappliedPartialPmt,
            string allowUnappliedPartialPmt,
            Decimal payoffAmount
            )
        {
            Description = description;
            Type = loanType;
            ID = loanId;
            Code = loanCode;
            ActivityDate = activityDate.ParseNullableSymDateString();
            CheckDigits = checkDigits;
            Reference = reference;
            Nickname = nickname;
            Branch = branch;
            CreatedByUser = createdByUser;
            CreatedAtBranch = createdAtBranch;
            LoanPurpose = loanPurpose;
            CouponCode = couponCode;
            VINNumber = vinNumber;
            MFOELID = mFOELId;
            NoteNumber = noteNumber;
            MICRAccountNumber = micrAccountNumber;
            LoanBalance = loanBalance;
            OriginalBalance = originalBalance;
            CreditLimit = creditLimit;
            AvailableCredit = availableCredit;
            CashAdvanceLimit = cashAdvanceLimit;
            AvailableCashAdvance = availableCashAdvance;
            BalanceTransferLimit = balanceTransferLimit;
            AvailableBalanceTransfer = availableBalanceTransfer;
            CombinedCABTLimit = combinedCABTLimit;
            AvailableCombinedCABT = availableCombinedCABT;
            CreditLimitExpiration = creditLimitExpiration.ParseNullableSymDateString();
            AvailableCreditCalculation = availableCreditCalculation;
            CreditLimitGroup = creditLimitGroup;
            AmountAdvanced = amountAdvanced;
            LastAdvanceDate = lastAdvanceDate.ParseNullableSymDateString();
            LastPaymentDate = lastPaymentDate.ParseNullableSymDateString();
            FirstPaymentDate = firstPaymentDate.ParseNullableSymDateString();
            PaymentType = paymentType;
            PaymentMethod = paymentMethod;
            PaymentFrequency = paymentFrequency;
            OriginalLoanDate = originalLoanDate.ParseNullableSymDateString();
            OpenDate = openDate.ParseNullableSymDateString();
            CloseDate = closeDate.ParseNullableSymDateString();
            Payment = payment;
            AlternatePayment = alternatePayment;
            AlternatePmtEffective = alternatePmtEffective.ParseNullableSymDateString();
            AlternatePmtExpiration = alternatePmtExpiration.ParseNullableSymDateString();
            PartialPayment = partialPayment;
            UnappliedPartialPayment = unappliedPartialPayment;
            StmtUnappliedPartialPmt = stmtUnappliedPartialPmt;
            AllowUnappliedPartialPmt = allowUnappliedPartialPmt;
            PayoffAmount = payoffAmount;
        }

        [SymConnectProperty]
        [JsonProperty]
        public string Description { get; set; }

        [SymConnectProperty("LoanType")]
        [JsonProperty("LoanType")]
        public string Type { get; set; }

        [SymConnectProperty("LoanID")]
        [JsonProperty("LoanID")]
        public string ID { get; set; }

        [SymConnectProperty("LoanCode")]
        [JsonProperty("LoanCode")]
        public LoanCode Code { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ActivityDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CheckDigits { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Reference { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Nickname { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int Branch { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedByUser { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreatedAtBranch { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int LoanPurpose { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public CouponCode CouponCode { get; set; }

        [SymConnectProperty("VIN#")]
        [JsonProperty("VIN#")]
        public string VINNumber { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string MFOELID { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string NoteNumber { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string MICRAccountNumber { get; set; }

        //Loan balance information

        [SymConnectProperty]
        [JsonProperty]
        public Decimal LoanBalance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal OriginalBalance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal CreditLimit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal AvailableCredit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal CashAdvanceLimit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal AvailableCashAdvance { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal BalanceTransferLimit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal AvailableBalanceTransfer { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal CombinedCABTLimit { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal AvailableCombinedCABT { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CreditLimitExpiration { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public AvailableCreditCalculationType AvailableCreditCalculation { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int CreditLimitGroup { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal AmountAdvanced { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastAdvanceDate { get; set; }

        //Payment Informatoin

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? LastPaymentDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? FirstPaymentDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public PaymentType PaymentType { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public PaymentMethod PaymentMethod { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public PaymentFrequency PaymentFrequency { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? OriginalLoanDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? OpenDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CloseDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal Payment { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal AlternatePayment { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? AlternatePmtEffective { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? AlternatePmtExpiration { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal PartialPayment { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal UnappliedPartialPayment { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal StmtUnappliedPartialPmt { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string AllowUnappliedPartialPmt { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal PayoffAmount { get; set; }


        #region subRecords

        /// <summary>
        /// Tracking sub records
        /// </summary>
        [JsonProperty]
        public List<Tracking> Tracking { get; set; }

        /// <summary>
        /// Loan sub records
        /// </summary>
        public List<Name> Names { get; set; }
        #endregion

    }

    public enum LoanCode
    {
        AvgDailyBalLOC,
        ClosedEnd,
        CreditCard,
        Lease,
        LineOfCredit,
        LOCCombination,
        OpenEnd
    }

    public enum CouponCode
    {
        Generate,
        Generated,
        Normal
    }

    public enum AvailableCreditCalculationType
    {
        NonRevolving,
        Revolving
    }

    public enum PaymentType
    {
        LevelPayment,
        LevelPrincipal
    }

    public enum PaymentMethod
    {
        AmortizationTransfer,
        AutoTransfer,
        Cash,
        Coupon,
        Distribution,
        DistributionAfterDue,
        Payroll,
        PayrollAfterDue,
        ScheduledAutoTransfer,
        ScheduledAutoTransferAfterDue
    }

    public enum PaymentFrequency
    {
        AmortizeSchedule,
        Annual,
        Bimonthly,
        Biweekly,
        BiweeklySkipFirst,
        BiweeklySkipLast,
        Immediate,
        Monthly,
        Quarterly,
        Semiannual,
        Semimonthly,
        SinglePay,
        Weekly,
        WeeklySkipFirst,
        WeeklySkipLast

    }
}
