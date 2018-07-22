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
    [SymConnectObject("Name")]
    [JsonObject]
    public class Name
    {
        [JsonConstructor]
        public Name(string title, string first, string middle, string last, string longName, int type, string suffix, int nameFormat, string homePhone, string workPhone, string workPhoneExtension, string mobilePhone,
                    int phoneType,
                    string pagerNumber,
                    string email,
                    string altEmail,
                    string dbaTitle,
                    string dbaFirst,
                    string dbaMiddle,
                    string dbaLast,
                    string dbaSuffix,
                    int dbaNameFormat,
                    string birthDate,
                    string deathDate,
                    string sex,
                    string mothersMaidenName,
                    string ssn,
                    int ssnTinType,
                    int usPersonFlag,
                    string employerName,
                    string occupation,
                    Decimal currGrossMonthPay,
                    Decimal currNetMonthPay,
                    string currMonthPayChgDate,
                    CTRExempt ctrExempt,
                    string userChar1,
                    string userChar2,
                    string userChar3,
                    string userChar4,
                    int locator,
                    string extendedName,

                    /*address fields */
                    AddressType addressType,
                    string street,
                    string city,
                    string state,
                    string zipCode,
                    string extraAddress,
                    string country,
                    string countryCode,
                    string carrierRoute,
                    /* identification fields*/
                    DocumentaryFlag identDocFlag1,
                    IDType identIdType1,
                    string identIdDescription1,
                    string identIdNumber1,
                    string identIdIssueDate1,
                    string identIdExpireDate1,
                    string identIdVerifyDate1,

                    DocumentaryFlag identDocFlag2,
                    IDType identIdType2,
                    string identIdDescription2,
                    string identIdNumber2,
                    string identIdIssueDate2,
                    string identIdExpireDate2,
                    string identIdVerifyDate2,

                    DocumentaryFlag identDocFlag3,
                    IDType identIdType3,
                    string identIdDescription3,
                    string identIdNumber3,
                    string identIdIssueDate3,
                    string identIdExpireDate3,
                    string identIdVerifyDate3
                    )
        {
            Title = title;
            First = first;
            Middle = middle;
            Last = last;
            ExtendedName = extendedName;
            LongName = longName;
            Type = type;
            Suffix = suffix;
            NameFormat = nameFormat;
            HomePhone = homePhone;
            WorkPhone = workPhone;
            WorkPhoneExtension = workPhoneExtension;
            MobilePhone = mobilePhone;
            PhoneType = phoneType;
            PagerNumber = pagerNumber;
            Email = email;
            AltEmail = altEmail;
            DBATitle = dbaTitle;
            DBAFirst = dbaFirst;
            DBAMiddle = dbaMiddle;
            DBALast = dbaLast;
            DBASuffix = dbaSuffix;
            DBANameFormat = dbaNameFormat;
            BirthDate = birthDate.ParseNullableSymDateString();
            DeathDate = deathDate.ParseNullableSymDateString();
            Sex = sex.ParseNullableSexString();
            MothersMaidenName = mothersMaidenName;
            SSN = ssn;
            SSNType = ssnTinType;
            USPersonFlag = usPersonFlag;
            EmployerName = employerName;
            Occupation = occupation;
            CurrGrossMonthPay = currGrossMonthPay;
            CurrNetMonthPay = currNetMonthPay;
            CurrMonthPayChgDate = currMonthPayChgDate.ParseNullableSymDateString();
            CTRExempt = ctrExempt;
            UserChar1 = userChar1;
            UserChar2 = userChar2;
            UserChar3 = userChar3;
            UserChar4 = userChar4;
            Locator = locator;

            Address = new Address()
            {
                AddressType = addressType,
                CarrierRoute = carrierRoute,
                City = city,
                Country = country,
                CountryCode = countryCode,
                ExtraAddress = extraAddress,
                State = state,
                Street = street,
                ZipCode = zipCode
            };

            IDs = new List<Identification>()
            {
                new Identification(){
                    IDENTDOCFLAG = identDocFlag1, IDENTIDDESCRIPTION = identIdDescription1, IDENTIDEXPIREDATE = identIdExpireDate1.ParseNullableSymDateString(), IDENTIDISSUEDATE = identIdIssueDate1.ParseNullableSymDateString(), IDENTIDNUMBER = identIdNumber1, IDENTIDTYPE = identIdType1, IDENTIDVERIFYDATE = identIdVerifyDate1.ParseNullableSymDateString()
                },
                new Identification(){
                    IDENTDOCFLAG = identDocFlag2, IDENTIDDESCRIPTION = identIdDescription2, IDENTIDEXPIREDATE = identIdExpireDate2.ParseNullableSymDateString(), IDENTIDISSUEDATE = identIdIssueDate2.ParseNullableSymDateString(), IDENTIDNUMBER = identIdNumber2, IDENTIDTYPE = identIdType2, IDENTIDVERIFYDATE = identIdVerifyDate2.ParseNullableSymDateString()
                },
                new Identification()
                {
                    IDENTDOCFLAG = identDocFlag3, IDENTIDDESCRIPTION = identIdDescription3, IDENTIDEXPIREDATE = identIdExpireDate3.ParseNullableSymDateString(), IDENTIDISSUEDATE = identIdIssueDate3.ParseNullableSymDateString(), IDENTIDNUMBER = identIdNumber3, IDENTIDTYPE = identIdType3, IDENTIDVERIFYDATE = identIdVerifyDate3.ParseNullableSymDateString()
                }

            };

        }
        [SymConnectProperty]
        [JsonProperty]
        public int Locator { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Title { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string First { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string Middle { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string Last { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string ExtendedName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string LongName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int Type { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Suffix { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int NameFormat { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string HomePhone { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string WorkPhone { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string WorkPhoneExtension { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string MobilePhone { get; set; }


        [SymConnectProperty]
        [JsonProperty]
        public int PhoneType { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string PagerNumber { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string Email { get; set; }

        /// <summary>
        /// Alternate email address
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string AltEmail { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string DBATitle { get; set; }

        /// <summary>
        /// Doing business as first name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string DBAFirst { get; set; }

        /// <summary>
        /// Doing business as middle name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string DBAMiddle { get; set; }

        /// <summary>
        /// Doing business as last name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string DBALast { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string DBASuffix { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int DBANameFormat { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? BirthDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? DeathDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Sex? Sex { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string MothersMaidenName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string SSN { get; set; }

        [SymConnectProperty("SSNTINType")]
        [JsonProperty("SSNTINType")]
        public int SSNType { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int USPersonFlag { get; set; }

        /// <summary>
        /// Current Employer
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string EmployerName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Occupation { get; set; }

        /// <summary>
        /// Current gross monthly pay
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public decimal CurrGrossMonthPay { get; set; }

        /// <summary>
        /// Current net monthly pay
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public decimal CurrNetMonthPay { get; set; }

        /// <summary>
        /// Current monthly pay updated date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CurrMonthPayChgDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public CTRExempt CTRExempt { get; set; }

        [SymConnectProperty(arraySize: 3)]
        [JsonProperty]
        public IEnumerable<Identification> IDs { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar1 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar2 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar3 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar4 { get; set; }

        [SymConnectProperty(isSubRecord: true)]
        [JsonProperty]
        public Address Address { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
    public enum CTRExempt
    {
        NotExempt,
        Exempt
    }

    public enum DocumentaryFlag
    {
        NonDocumentaryIdentification,
        DocumentaryIdentification
    }
}
