using System;
using System.Collections.Generic;

namespace CreditApp.Entities
{
    public class Journal
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public virtual Account Account { get; set; }
        public ICollection<Ledger> Ledgers { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
