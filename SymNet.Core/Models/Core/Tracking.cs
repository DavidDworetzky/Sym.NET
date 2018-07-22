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
    [SymConnectObject("Tracking", SymConnectObjectSerialization.Explicit)]
    [JsonObject]
    public class Tracking
    {
        public Tracking(int type, int trackingCode, string creationDate, string creationTime, int userId,
            string fmLastDate, string recordChangeDate, string expireDate,
            int usercode1,
            int usercode2,
            int usercode3,
            int usercode4,
            int usercode5,
            int usercode6,
            int usercode7,
            int usercode8,
            int usercode9,
            int usercode10,
            string userchar1,
            string userchar2,
            string userchar3,
            string userchar4,
            string userchar5,
            string userchar6,
            string userchar7,
            string userchar8,
            string userchar9,
            string userchar10,
            Decimal useramount1,
            Decimal useramount2,
            Decimal useramount3,
            Decimal useramount4,
            Decimal useramount5,
            Decimal useramount6,
            Decimal useramount7,
            Decimal useramount8,
            Decimal useramount9,
            Decimal useramount10,
            Decimal userrate1,
            Decimal userrate2,
            Decimal userrate3,
            Decimal userrate4,
            Decimal userrate5,
            Decimal userrate6,
            Decimal userrate7,
            Decimal userrate8,
            Decimal userrate9,
            Decimal userrate10,
            string id,
            int locator,
            string userdate1,
            string userdate2,
            string userdate3,
            string userdate4,
            string userdate5,
            string userdate6,
            string userdate7,
            string userdate8,
            string userdate9,
            string userdate10

            )
        {
            Type = type;
            TrackingCode = trackingCode;
            CreationDate = creationDate.ParseNullableSymDateString();
            CreationTime = creationTime.ParseNullableSymHoursAndMinutesString();
            UserId = userId;
            FMLastDate = fmLastDate.ParseNullableSymDateString();
            RecordChangeDate = recordChangeDate.ParseNullableSymDateString();
            ExpireDate = expireDate.ParseNullableSymDateString();
            UserCode1 = usercode1;
            UserCode2 = usercode2;
            UserCode3 = usercode3;
            UserCode4 = usercode4;
            UserCode5 = usercode5;
            UserCode6 = usercode6;
            UserCode7 = usercode7;
            UserCode8 = usercode8;
            UserCode9 = usercode9;
            UserCode10 = usercode10;
            UserChar1 = userchar1;
            UserChar2 = userchar2;
            UserChar3 = userchar3;
            UserChar4 = userchar4;
            UserChar5 = userchar5;
            UserChar6 = userchar6;
            UserChar7 = userchar7;
            UserChar8 = userchar8;
            UserChar9 = userchar9;
            UserChar10 = userchar10;
            UserAmount1 = useramount1;
            UserAmount2 = useramount2;
            UserAmount3 = useramount3;
            UserAmount4 = useramount4;
            UserAmount5 = useramount5;
            UserAmount6 = useramount6;
            UserAmount7 = useramount7;
            UserAmount8 = useramount8;
            UserAmount9 = useramount9;
            UserAmount10 = useramount10;
            UserRate1 = userrate1;
            UserRate2 = userrate2;
            UserRate3 = userrate3;
            UserRate4 = userrate4;
            UserRate5 = userrate5;
            UserRate6 = userrate6;
            UserRate7 = userrate7;
            UserRate8 = userrate8;
            UserRate9 = userrate9;
            UserRate10 = userrate10;
            Id = id;
            Locator = locator;
            UserDate1 = userdate1.ParseNullableSymDateString();
            UserDate2 = userdate2.ParseNullableSymDateString();
            UserDate3 = userdate3.ParseNullableSymDateString();
            UserDate4 = userdate4.ParseNullableSymDateString();
            UserDate5 = userdate5.ParseNullableSymDateString();
            UserDate6 = userdate6.ParseNullableSymDateString();
            UserDate7 = userdate7.ParseNullableSymDateString();
            UserDate8 = userdate8.ParseNullableSymDateString();
            UserDate9 = userdate9.ParseNullableSymDateString();
            UserDate10 = userdate10.ParseNullableSymDateString();


        }

        [SymConnectProperty]
        [JsonProperty]
        public string Id { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public int Locator { get; set; }
        /// <summary>
        /// Tracking type
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public int Type { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int TrackingCode { get; set; }

        /// <summary>
        /// Creation DateTime of record
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? CreationDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public TimeSpan? CreationTime { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserId { get; set; }

        /// <summary>
        /// Last file maintenance date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? FMLastDate { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public DateTime? RecordChangeDate { get; set; }

        /// <summary>
        /// Record expiration date
        /// </summary>
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// 10 User codes, chars, amounts and rates in tracking records
        /// </summary>


        //User codes
        [SymConnectProperty]
        [JsonProperty]
        public int UserCode1 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode2 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode3 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode4 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode5 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode6 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode7 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode8 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode9 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public int UserCode10 { get; set; }

        //user chars

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

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar5 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar6 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar7 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar8 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar9 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public string UserChar10 { get; set; }

        // user amounts

        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount1 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount2 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount3 { get; set; }

        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount4 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount5 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount6 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount7 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount8 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount9 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserAmount10 { get; set; }

        //user rates
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate1 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate2 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate3 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate4 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate5 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate6 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate7 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate8 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate9 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public Decimal UserRate10 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate1 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate2 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate3 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate4 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate5 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate6 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate7 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate8 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate9 { get; set; }
        [SymConnectProperty]
        [JsonProperty]
        public DateTime? UserDate10 { get; set; }


    }
}
