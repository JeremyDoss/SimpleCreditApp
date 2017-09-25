using System;

namespace CreditApp.Entities
{
    public class LedgerRecord
    {
        public int Id { get; set; }
        public int LedgerId { get; set; }
        public int TransactionId { get; set; }
        public string Type { get; set; } // credit/debit
        public double Amount { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public virtual Ledger Ledger { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
