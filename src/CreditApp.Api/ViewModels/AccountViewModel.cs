using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApp.Api.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public double Principal { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; } = Enumerable.Empty<TransactionViewModel>();
    }
}
