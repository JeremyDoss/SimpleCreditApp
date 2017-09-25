using System;
using System.Collections.Generic;

namespace CreditApp.Entities
{
    public class Account
    {
        public Account()
        {

        }

        public Account(string userName)
        {
            UserName = userName;
            Created = DateTime.Now;
            Journals = new List<Journal>()
            {
                new Journal()
            };
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public ICollection<Journal> Journals { get; set; }
    }
}
