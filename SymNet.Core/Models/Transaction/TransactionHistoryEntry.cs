using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Models.Transaction
{
    public class TransactionHistoryEntry
    {
        public string Description { get; set; }

        public Decimal Amount { get; set; }

        public DateTime? EffectiveDate { get; set; }
    }
}
