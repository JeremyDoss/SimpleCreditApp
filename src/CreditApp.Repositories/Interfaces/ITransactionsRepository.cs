using CreditApp.Entities;
using System.Threading.Tasks;

namespace CreditApp.Repositories.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<bool> RecordTransactionAsync(int userId, Transaction transaction);
    }
}
