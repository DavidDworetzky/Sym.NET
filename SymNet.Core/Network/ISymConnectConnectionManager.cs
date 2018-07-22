using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymNet.Core.Models;

namespace SymNet.Core.Network
{
    public interface ISymConnectConnectionManager
    {
        /// <summary>
        /// Sends a symitar message either through direct request or parameterized message (by session)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="rgMessageParameterizedGenerator"></param>
        /// <returns></returns>
        Task<string> SendSymMessage(string requestMessage = null,
            Func<int, string> rgMessageParameterizedGenerator = null);

        /// <summary>
        /// Sets a symconnect configuration
        /// </summary>
        SymConnectConfiguration SymConnectConfiguration { set; }

        /// <summary>
        /// Force restart specific symconnect hosts
        /// </summary>
        /// <param name="restartAction"></param>
        /// <param name="symServerFilter"></param>
        void ForceRestartSpecificHosts(Action restartAction = null, Func<SymServer, bool> symServerFilter = null);

        /// <summary>
        /// Return port status upstream
        /// </summary>
        IEnumerable<PortStatus> PortStatus { get; }
    }
}
