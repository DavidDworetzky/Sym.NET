using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymNet.Core.Serialization;

namespace SymNet.Core.Models.Core
{
    [JsonObject]
    public class Identification
    {
        /// <summary>
        /// Documentary flag one
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DocumentaryFlag IDENTDOCFLAG { get; set; }

        /// <summary>
        /// Identity ID Type 1
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public IDType IDENTIDTYPE { get; set; }

        /// <summary>
        /// Identity ID Description
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string IDENTIDDESCRIPTION { get; set; }

        /// <summary>
        /// Identity ID Number
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public string IDENTIDNUMBER { get; set; }

        /// <summary>
        /// Identity issuance date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? IDENTIDISSUEDATE { get; set; }

        /// <summary>
        /// Identity expriation date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? IDENTIDEXPIREDATE { get; set; }

        /// <summary>
        /// Identity verification date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? IDENTIDVERIFYDATE { get; set; }
    }

    public enum IDType
    {
        Unknown,
        KnownExistingMember,
        StateDriversLicense,
        StateIdCard,
        USPassport,
        ForeignPassport,
        MilitaryIdCard,
        ForeignGovernmentIssuedId,
        ResidentAlienCard,
        DisabledElderlyWithNoId,
        ForeignEntityWithNoId,
        LawEnforcement,
        AmishCustomerWithNoId
    }
}
