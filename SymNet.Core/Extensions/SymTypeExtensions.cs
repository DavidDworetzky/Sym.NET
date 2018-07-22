using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymNet.Core.Models.Core;

namespace SymNet.Core.Extensions
{
    public static class SymTypeExtensions
    {
        public static DateTime ParseSymDateString(this string str)
        {
            return DateTime.Parse(str);
        }

        /// <summary>
        /// Parses a nullable sym date string, where empty is either blank or of the format "--/--/----"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ParseNullableSymDateString(this string str)
        {
            return String.IsNullOrWhiteSpace(str) || str.Contains("--/--/----") ? (DateTime?)null : DateTime.Parse(str);
        }

        /// <summary>
        /// Parses a symitar string of the format "m", "f" or "" for symitar name records
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Sex? ParseNullableSexString(this string str)
        {
            return String.IsNullOrEmpty(str) ? (Sex?)null : str.ToLower().Contains("m") ? Sex.Male : str.ToLower().Contains("f") ? Sex.Female : (Sex?)null;
        }

        /// <summary>
        /// Parses symitar time formats that come in a "HHMM" format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan ParseSymHourAndMinutesString(this string str)
        {
            string minutesString = str.Substring(2);
            string hoursString = str.Substring(0, 2);

            //parse out our hours and minutes
            int minutes = Int32.Parse(minutesString);
            //if there is no hours string, it is at 0:00 hours
            int hours = String.IsNullOrEmpty(hoursString) ? Int32.Parse(hoursString) : 0;

            //now create our timespan and generate 
            var hoursSpan = TimeSpan.FromHours(hours);
            var minutesSpan = TimeSpan.FromMinutes(minutes);

            return hoursSpan.Add(minutesSpan);

        }
        /// <summary>
        /// Parse a nullable time that comes in "HHMM" format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? ParseNullableSymHoursAndMinutesString(this string str)
        {
            return str?.ParseSymHourAndMinutesString();
        }
    }
}
