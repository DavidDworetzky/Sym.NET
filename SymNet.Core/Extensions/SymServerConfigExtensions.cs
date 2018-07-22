using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymNet.Core.Network;

namespace SymNet.Core.Extensions
{
    public static class SymServerConfigExtensions
    {
        /// <summary>
        /// Converts a string of format IP:PORT:RGSESSION REC1,REC2 to sym server configuration list
        /// </summary>
        /// <param name="hostsString"></param>
        /// <returns></returns>
        public static IEnumerable<SymServerConfig> ToSymServerConfig(this string hostsString)
        {
            return
                hostsString.Split(',')
                    .Select(
                        ipPort =>
                            new SymServerConfig(Convert.ToInt32(ipPort.Split(':')[1]), ipPort.Split(':')[0],
                                Convert.ToInt32(ipPort.Split(':')[2])));
        }
    }
}
