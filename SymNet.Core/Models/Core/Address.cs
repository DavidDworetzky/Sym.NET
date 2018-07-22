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
    public class Address
    {

        [SymConnectProperty]
        [JsonProperty]
        public AddressType AddressType { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Street { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string City { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string State { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string ZipCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string ExtraAddress { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string Country { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CountryCode { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string CarrierRoute { get; set; }
    }

    public enum AddressType
    {
        Domestic,
        Foreign,
        ForeignZipLast
    
    }
}
