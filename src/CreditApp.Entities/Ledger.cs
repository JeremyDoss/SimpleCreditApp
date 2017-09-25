using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Entities
{
    public class Ledger
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public string Type { get; set; } // cash-out/principal
        public DateTime Created { get; set; } = DateTime.Now;

        public virtual Journal Journal { get; set; }
        public ICollection<LedgerRecord> LedgerRecords { get; set; }
    }
}
