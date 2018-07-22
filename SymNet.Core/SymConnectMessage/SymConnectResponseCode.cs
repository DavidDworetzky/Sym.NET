using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.SymConnectMessage
{
    public enum ResponseCode
    {

        //Success codes
        Success = 0,
        //Warning codes
        SymConnectOffHost = 1,
        UserCodeRequired = 2,
        PasswordChangeRequired = 3,
        SecondPasswordWillBeRequired = 4,
        SecondPasswordRequired = 5,
        HBPasswordChangeRequired = 6,
        InvalidRequestField = 101,
        RewindError = 201,
        WriteError = 202,
        InvalidSpecfileRequestField = 1001,
        TooManySpecfileAnswers = 1002,
        MoreSpecfileLines = 1003,
        SpecfileExecutedDuringMemoPostMode = 1004,
        CannotPullCreditReport = 1005,
        CannotPullCreditReportAccountInUse = 1006,
        CreditReportError = 1007,
        CopyApplicationErrorInuse = 1008,
        CopyApplicationError = 1009,
        FmPartialCompletion = 2001,
        FmPerformedDuringMemoPostMode = 2002,
        RecordTypeCannotBeQueued = 2003,
        InvalidQueue = 2004,
        InvalidPriority = 2005,
        MissingQueue = 2006,
        FeePostingError = 3001,
        HoldPostingError = 3002,
        AuthorizationHoldsUnreversible = 3003,
        TransactionPostingError = 3999,
        OutOfBalanceError = 4001,
        CashBalancingNotUsed = 4002,
        DepositBalancingNotUsed = 4003,
        CheckBalancingNotUsed = 4004,
        NoReferenceAccountsFound = 4005,
        RemoteProcedureFieldsExceededOutput = 5001,
        MaximumSpecfileLinesOutOfBounds = 9001,
        MaximumAllFieldCountSettingOutOfBounds = 9002,

        //Error messages

        MissingMessageType = 10001,
        MissingMessageID = 10002,
        MissingDeviceNumber = 10003,
        DuplicateDeviceNumber = 10004,
        InvalidDeviceNumber = 10005,
        MissingDeviceType = 10006,
        DuplicateDeviceType = 10007,
        MissingUnitLocation = 10008,
        DuplicateUnitLocation = 10009,
        MissingAccountNumber = 10010,
        DuplicateAccountNumber = 10011,
        MissingUserCode = 10012,
        DuplicateUserCode = 10013,
        MissingAccessCode = 10014,
        DuplicateAccessCode = 10015,
        MissingFile = 10016,
        DuplicateFile = 10017,
        MissingRecordPath = 10018,
        DuplicateRecordPath = 10019,
        MissingRecord = 10020,
        TooManyRecords = 10021,
        InvalidFileNumber = 10022,
        InvalidRecordNumber = 10023,
        TooManyFieldsRequested = 10024,
        MissingRequestField = 10025,
        InvalidFieldIdentifier = 10026,
        MissingAdministrativeRequestType = 10027,
        DuplicateAdministrativeRequestType = 10028,
        MissingUserNumber = 10029,
        DuplicateUserNumber = 10030,
        MissingUserPassword = 10031,
        DuplicateUserPassword = 10032,
        MissingOverrideUserNumber = 10033,
        DuplicateOverrideUserNumber = 10034,
        MissingOverrideUserPassword = 10035,
        DuplicateOverrideUserPassword = 10036,
        UserNumberOutOfRange = 10037,
        NullRecordModifier = 10038,
        DuplicateRecordModifier = 10039,
        InvalidRecordModifier = 10040,
        MissingSecondPassword = 10041,
        DuplicateSecondPassword = 10042,
        RequestFormatError = 10100,
        InvalidCardNumber = 10101,
        InvalidRecordPath = 10201,
        FieldLevelError = 12003,
        GeneralError = 19999
    }

    public static class SymConnectResponseExtensions
    {

        /// <summary>
        /// Mutually exclusive with error override. Cannot be an error code and a success code at the same time
        /// </summary>
        public static ResponseCode[] SuccessOverride = { ResponseCode.FmPerformedDuringMemoPostMode, ResponseCode.SpecfileExecutedDuringMemoPostMode, };

        /// <summary>
        /// Mutually exclusive with success override. Cannot be an error code and a success code at the same time
        /// </summary>
        public static ResponseCode[] ErrorOverride = { ResponseCode.SymConnectOffHost };


        public static bool IsWarning(this ResponseCode response)
        {
            int code = (int)response;

            //within warning range, and is not an error or success code
            return (code > 0 && code < 10000) && !ErrorOverride.Contains(response) && !SuccessOverride.Contains(response);
        }

        public static bool IsError(this ResponseCode response)
        {
            int code = (int)response;

            return (code > 10000 || ErrorOverride.Contains(response));
        }

        public static bool IsSuccess(this ResponseCode response)
        {
            int code = (int)response;

            return (code == 0 || SuccessOverride.Contains(response));
        }

    }
}
