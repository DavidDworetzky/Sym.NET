using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.SymConnectMessage
{
    /// <summary>
    /// String builder class for symconnect requests
    /// </summary>
    public class SymConnectRequestMessage
    {
        #region PrivateMembers

        #region Common
        private SymConnectMessageType Type { get; set; }

        private int UnitNumber { get; set; }

        private string VendorName { get; set; }

        private string SourceAccount { get; set; }

        private string TargetAccount { get; set; }

        private string CardNumber { get; set; }

        #endregion

        /// <summary>
        /// Name of our chosen repgen
        /// </summary>
        private SymConnectRequestMessage.RepgenInfo Repgen { get; set; }

        /// <summary>
        /// The locator of the record in question
        /// </summary>
        private IEnumerable<SymConnectRequestMessage.RecordDesignation> SourceLocators { get; set; }

        private IEnumerable<SymConnectRequestMessage.RecordDesignation> TargetLocators { get; set; }

        /// <summary>
        /// Requested fields in an IQ
        /// </summary>
        private IEnumerable<string> SourceFields { get; set; }

        /// <summary>
        /// Target values in an FM transaction
        /// </summary>
        private Dictionary<string, string> TargetFields { get; set; }

        /// <summary>
        /// FM create or revise
        /// </summary>
        private SymConnectFMType? FmType { get; set; }

        /// <summary>
        /// Request ID
        /// </summary>
        public Guid RequestId { get; set; }

        /// <summary>
        /// Reserved symconnect characters
        /// </summary>
        private static readonly char[] ReservedFieldChars = { '~', '=' };

        #endregion
        #region Constructors

        /// <summary>
        /// For IQ Messages
        /// </summary>
        /// <param name="type"></param>
        /// <param name="vendorName"></param>
        /// <param name="cardNumber"></param>
        /// <param name="accountNumber"></param>
        /// <param name="locator"></param>
        public SymConnectRequestMessage(int unitNumber, SymConnectMessageType type, string vendorName, string cardNumber, string accountNumber, IEnumerable<SymConnectRequestMessage.RecordDesignation> locator, IEnumerable<string> sourceFields)
            : this(unitNumber, type, vendorName, accountNumber, cardNumber)
        {
            if (type != SymConnectMessageType.IQ)
            {
                throw new System.InvalidOperationException("Invalid constructor for a symconnect message of type IQ");
            }
            SourceLocators = locator;
            SourceFields = sourceFields;

            ValidateSymConnectContent();
        }

        /// <summary>
        /// For FM Messages
        /// </summary>
        /// <param name="unitNumber"></param>
        /// <param name="type"></param>
        /// <param name="vendorName"></param>
        /// <param name="cardNumber"></param>
        /// <param name="accountNumber"></param>
        /// <param name="locator"></param>
        /// <param name="targetFields"></param>
        /// <param name="fmType"></param>
        public SymConnectRequestMessage(int unitNumber, SymConnectMessageType type, string vendorName, string cardNumber,
            string accountNumber, IEnumerable<SymConnectRequestMessage.RecordDesignation> locator,
            Dictionary<string, string> targetFields, SymConnectFMType fmType)
            : this(unitNumber, type, vendorName, accountNumber, cardNumber)
        {
            if (type != SymConnectMessageType.FM)
            {
                throw new System.InvalidOperationException("Invalid constructor for a symconnect message of type FM");
            }
            SourceLocators = locator;
            //TargetLocators = locator;
            TargetFields = targetFields;
            FmType = fmType;

            ValidateSymConnectContent();

        }
        /// <summary>
        /// For TR requests
        /// </summary>
        /// <param name="type"></param>
        /// <param name="vendorName"></param>
        /// <param name="accountNumber"></param>
        /// <param name="cardNumber"></param>
        /// <param name="sourceLocator"></param>
        /// <param name="targetAccount"></param>
        /// <param name="targetLocator"></param>
        public SymConnectRequestMessage(int unitNumber, SymConnectMessageType type, string vendorName, string cardNumber, string accountNumber, IEnumerable<SymConnectRequestMessage.RecordDesignation> sourceLocator, string targetAccount, IEnumerable<SymConnectRequestMessage.RecordDesignation> targetLocator)
            : this(unitNumber, type, vendorName, accountNumber, cardNumber)
        {
            if (type != SymConnectMessageType.TR)
            {
                throw new System.InvalidOperationException("Invalid constructor for a symconnect message of type TR");
            }
            SourceLocators = sourceLocator;
            TargetAccount = targetAccount;
            TargetLocators = targetLocator;
            ValidateSymConnectContent();

        }

        public SymConnectRequestMessage(int unitNumber, SymConnectMessageType type, string vendorName, string cardNumber, string accountNumber, RepgenInfo info)
            : this(unitNumber, type, vendorName, accountNumber, cardNumber)
        {
            if (type != SymConnectMessageType.RG)
            {
                throw new System.InvalidOperationException("Invalid parameters for symconnect message of type RG");
            }
            Repgen = info;
            ValidateSymConnectContent();
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="vendorName"></param>
        /// <param name="accountNumber"></param>
        /// <param name="cardNumber"></param>
        /// <param name="sourceLocators"></param>
        public SymConnectRequestMessage(int unitNumber, SymConnectMessageType type, string vendorName, string accountNumber, string cardNumber)
        {
            RequestId = Guid.NewGuid();
            CardNumber = cardNumber;
            VendorName = vendorName;
            Type = type;
            UnitNumber = unitNumber;

            //pad requests with less than 10 
            if (accountNumber.Length < 10)
            {
                accountNumber = Enumerable.Repeat<char>('0', 10 - accountNumber.Length).Aggregate("", (x, y) => x + y) + accountNumber;
            }
            //if greater than 10, throw an exception

            if (accountNumber.Length > 10)
            {
                throw new InvalidOperationException("Cannot make a symconnect request with an account number with greater than 10 digits");
            }

            SourceAccount = accountNumber;
        }
        #endregion

        #region Helpers
        private string FormatSourceRecord()
        {
            if (!SourceLocators.Any())
            {
                return String.Empty;
            }
            //our first component is ~H for the hierarchic record path
            string firstPart = "~H";
            string secondPart = String.Empty;
            //second part is the delimited list of record with locator / ordinal / id information
            secondPart = SourceLocators.Aggregate(String.Empty,
                       //each record in the hierarchical path is separated by : as a delimiter
                       (s, designation) => s + ":" +
                                           String.Format("{0}{1}{2}{3}", designation.Type,
                                               !String.IsNullOrEmpty(designation.SubType) ? "~JTYPE=" : String.Empty,
                                               designation.SubType,
                                               !String.IsNullOrEmpty(designation.Locator)
                                                   //Locators are proceeded by = in the symconnect string
                                                   //Ids and Ordinals are proceeded by -
                                                   ? String.Format("{0}{1}",
                                                       designation.LocatorType == SymConnectLocatorType.Ordinal ? "="
                                                           : designation.LocatorType == SymConnectLocatorType.Id ? "#" : "-", designation.Locator)
                                                   : String.Empty));
            //shave off the first : delimiter
            if (SourceLocators.Any())
            {
                secondPart = secondPart.Substring(1, secondPart.Length - 1);
            }
            return firstPart + secondPart;
        }

        private bool ContainsReservedChars(string testString)
        {
            //or that one of the reserved characters is contained in testString to see if it is contained
            return ReservedFieldChars.Aggregate(false, (current, reserved) => current || testString.Contains(reserved));
        }

        private void ValidateSymConnectContent()
        {
            //if the repgen name or parameters contain reserved characters, throw an exception
            if (Type == SymConnectMessageType.RG && (ContainsReservedChars(Repgen.RepgenName) ||
                Repgen.RepgenParameters.Aggregate(false, (agg, kvp) => agg || ContainsReservedChars(kvp.Key) || ContainsReservedChars(kvp.Value))))
            {
                throw new InvalidOperationException("Repgen name or parameters cannot contain symconnect reserved characters");
            }
            //if any of the source fields contain reserved characters, throw an exception
            if (Type == SymConnectMessageType.IQ && SourceFields.Aggregate(false, (agg, str) => agg || ContainsReservedChars(str)))
            {
                throw new InvalidOperationException("Source fields for iq cannot contain symconnect reserved characters");
            }
            //if any of the target fields contain reserved characters, throw an exception
            if (Type == SymConnectMessageType.FM &&
                TargetFields.Aggregate(false,
                    (agg, kvp) => agg || ContainsReservedChars(kvp.Key) || ContainsReservedChars(kvp.Value)))
            {
                throw new InvalidOperationException("Target fields for fm cannot contain symconnect reserved characters");
            }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //Message Type
            sb.Append(Type.ToString());
            //Requestid
            sb.Append(String.Format("~{0}", RequestId.ToString()));
            //UnitNumber
            sb.Append(String.Format("~A{0}", UnitNumber));
            //VendorId
            sb.Append(String.Format("~B{0}", VendorName));
            //D-F CardNumber based access
            sb.Append(String.Format("~DCARD~F{0}{1}", CardNumber, SourceAccount));
            //G and H fields Repgen Name / Locator Names
            sb.Append(Type == SymConnectMessageType.RG ? String.Format("~G{0}", Repgen.RepgenName) : String.Empty);
            //H - record locator
            sb.Append(Type == SymConnectMessageType.IQ || Type == SymConnectMessageType.FM ? FormatSourceRecord() : String.Empty);
            //Optional J params for FM
            sb.Append(Type == SymConnectMessageType.FM && FmType != null ? String.Format("~JFMTYPE={0}", (int)FmType.Value) : String.Empty);
            //J Params .. For Repgen calls, this is JRGSESSION, etc. For IQs this is our record locators, for FMs this is our revised fields, for TRS, nothing
            sb.Append(
                Type == SymConnectMessageType.RG
                    //RG J params
                    ? Repgen.RepgenParameters.Aggregate(String.Empty,
                        (x, y) => x + String.Format("~JRG{0}={1}", y.Key, y.Value)) +
                      String.Format("~JRGSESSION={0}", Repgen.RepgenSession)
                    //TR, nothing
                    : Type == SymConnectMessageType.TR
                        ? String.Empty
                        //IQ source fields
                        : Type == SymConnectMessageType.IQ
                            ? SourceFields.Aggregate(String.Empty, (x, y) => x + String.Format("~J{0}", y))
                            //FM fields
                            : Type == SymConnectMessageType.FM
                                ? TargetFields.Aggregate(String.Empty,
                                    (s, pair) => s + String.Format("~J{0}={1}", pair.Key, pair.Value))
                                : String.Empty);



            return sb.ToString();
        }
        #region SubRecords

        public class RecordDesignation
        {

            public RecordDesignation(string type, string subType, string locator, SymConnectLocatorType locatorType)
            {
                Type = type;
                SubType = subType;
                Locator = locator;
                LocatorType = locatorType;

                if (String.IsNullOrEmpty(type) && String.IsNullOrEmpty(subType))
                {
                    throw new System.InvalidOperationException("You must provide a valid type and subtype for a record designation");
                }
            }
            /// <summary>
            /// The type of record that we are looking for
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// The subtype of record that we are looking for >> applicable to tracking and note records
            /// </summary>
            public string SubType { get; set; }

            /// <summary>
            /// The record locator. Optional.
            /// </summary>
            public string Locator { get; set; }

            /// <summary>
            /// Specifies the type of access we use to specify a record
            /// </summary>
            public SymConnectLocatorType LocatorType { get; set; }
        }

        public enum SymConnectLocatorType
        {
            Ordinal,
            Locator,
            Id
        }

        public class RepgenInfo
        {
            public RepgenInfo(string repgenName, int repgenSession, Dictionary<string, string> repgenParameters)
            {
                RepgenName = repgenName;
                RepgenSession = repgenSession;
                RepgenParameters = repgenParameters ?? new Dictionary<string, string>();

                if (String.IsNullOrEmpty(repgenName))
                {
                    throw new System.InvalidOperationException("Cannot instantiate repgen info without a repgen name");
                }
            }

            /// <summary>
            /// The name of the repgen to execute
            /// </summary>
            public string RepgenName { get; set; }

            /// <summary>
            /// Our current RGSESSION number
            /// </summary>
            public int RepgenSession { get; set; }

            /// <summary>
            /// Tuple of repgen parameters to pass into the repgen
            /// </summary>
            public Dictionary<string, string> RepgenParameters { get; set; }
        }
        #endregion SubRecords
    }
}
