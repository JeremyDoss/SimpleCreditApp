using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Repositories.Interfaces
{
    public interface ITransactionsRepository
    {
        bool ApplyTransaction();
    }
}
