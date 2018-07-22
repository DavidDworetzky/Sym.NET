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
    [SymConnectObject("CredRep", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class CreditReport
    {
        [JsonConstructor]
        public CreditReport(int source, string bureau, string subscriberCode, string queueCode, string queueAfterDate,
            string queueAfterTime,
            string optFeatureCode,
            int requestNumber,
            string requestDate,
            string requestTime,
            int user,
            string completionCode,
            string completionTime,
            string commercialCode,
            string strategyType,
            string firstName,
            string middleName,
            string lastName,
            string ssn,
            string birthDate,
            string idState1,
            string idNumber1,
            string spouseFirst,
            string spouseMiddle,
            string spouseLast,
            string spouseSSN,
            string spouseBirthDate,
            string idState2,
            string idNumber2,
            string currAddrStreetName,
            string currAddrCity,
            string currAddrState,
            string currAddrZipCode,
            string currAddrHomePhone,
            string userId,
            string password,
            string completionDate,
            int locator
            )
        {
            Source = source;
            Bureau = bureau;
            SubscriberCode = subscriberCode;
            QueueCode = queueCode;
            QueueAfterDate = queueAfterDate.ParseNullableSymDateString();
            QueueAfterTime = queueAfterTime.ParseNullableSymHoursAndMinutesString();
            OptFeatureCode = optFeatureCode;
            RequestNumber = requestNumber;
            RequestDate = requestDate.ParseNullableSymDateString();
            RequestTime = requestTime.ParseNullableSymHoursAndMinutesString();
            User = user;
            CompletionCode = completionCode;
            CompletionDate = completionDate.ParseNullableSymDateString();
            CompletionTime = completionTime.ParseNullableSymHoursAndMinutesString();
            CommercialCode = commercialCode;
            StrategyType = strategyType;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            SSN = ssn;
            BirthDate = birthDate.ParseNullableSymDateString();
            IDState1 = idState1;
            int idNum1;
            Int32.TryParse(idNumber1, out idNum1);
            IDNumber1 = idNum1;
            SpouseFirst = spouseFirst;
            SpouseMiddle = spouseMiddle;
            SpouseLast = spouseLast;
            SpouseSSN = spouseSSN;
            SpouseBirthDate = spouseBirthDate.ParseNullableSymDateString();
            IDState2 = idState2;
            int idNum2;
            Int32.TryParse(idNumber2, out idNum2);
            IDNumber2 = idNum2;
            CurrAddrStreetName = currAddrStreetName;
            CurrAddrCity = currAddrCity;
            CurrAddrState = currAddrState;
            CurrAddrZipCode = currAddrZipCode;
            CurrAddrHomePhone = currAddrHomePhone;
            UserId = userId;
            Password = password;
            Locator = locator;
        }
        [SymConnectProperty]
        [JsonProperty]
        public int Locator { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int Source { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Bureau { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string SubscriberCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string QueueCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? QueueAfterDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TimeSpan? QueueAfterTime { get; set; }

        /// <summary>
        /// Optional feature code
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string OptFeatureCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int RequestNumber { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RequestDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TimeSpan? RequestTime { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int User { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CompletionCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CompletionDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TimeSpan? CompletionTime { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CommercialCode { get; set; }

        //Options
        [SymConnectProperty]
        [JsonProperty]
        public string StrategyType { get; set; }


        //Name information

        [SymConnectProperty]
        [JsonProperty]
        public string FirstName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string MiddleName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string LastName { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string SSN { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// ID State 1
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string IDState1 { get; set; }

        /// <summary>
        /// ID Number 1
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public int IDNumber1 { get; set; }

        //Spouse information

        /// <summary>
        /// Spouse first name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string SpouseFirst { get; set; }

        /// <summary>
        /// Spouse middle name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string SpouseMiddle { get; set; }

        /// <summary>
        /// Spouse last name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string SpouseLast { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string SpouseSSN { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? SpouseBirthDate { get; set; }

        /// <summary>
        /// Identification state 2
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string IDState2 { get; set; }

        /// <summary>
        /// Identifcation number 2
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public int IDNumber2 { get; set; }

        //Current Address

        /// <summary>
        /// Current address street name
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string CurrAddrStreetName { get; set; }

        /// <summary>
        /// Current address city
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string CurrAddrCity { get; set; }

        /// <summary>
        /// Current address state
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string CurrAddrState { get; set; }

        /// <summary>
        /// Current address zip code
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string CurrAddrZipCode { get; set; }

        /// <summary>
        /// Current address home phone
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string CurrAddrHomePhone { get; set; }

        //Settings

        [SymConnectProperty]
        [JsonProperty]
        public string UserId { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Password { get; set; }
    }
}
