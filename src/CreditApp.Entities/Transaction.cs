using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditApp.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public string Type { get; set; } // purchase/payment
        public double Amount { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public virtual Journal Journal { get; set; }
        public ICollection<LedgerRecord> LedgerRecords { get; set; } = new List<LedgerRecord>();
    }
}
