using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Entities
{
    public class Journal
    {
        public Journal()
        {
            Created = DateTime.Now;
            Ledgers = new List<Ledger>() {
                new Ledger("cash-out"),
                new Ledger("principal")
            };
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public virtual Account Account { get; set; }
        public ICollection<Ledger> Ledgers { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
