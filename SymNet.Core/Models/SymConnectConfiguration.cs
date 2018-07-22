using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymNet.Core.Network;

namespace SymNet.Core.Models
{
    public class SymConnectConfiguration
    {

        public SymConnectConfiguration(IEnumerable<SymServerConfig> config, int maxBufferSize, int maxRetries, int retryIntervalSeconds)
        {
            Config = config;
            MaxBufferSize = maxBufferSize;
            MaxRetries = maxRetries;
            RetryIntervalSeconds = retryIntervalSeconds;
        }

        public IEnumerable<SymServerConfig> Config { get; set; }

        public int MaxBufferSize { get; set; }

        public int MaxRetries { get; set; }

        public int RetryIntervalSeconds { get; set; }


    }
}
