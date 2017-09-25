using CreditApp.Entities;
using System.Threading.Tasks;

namespace CreditApp.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<Account> CreateAccountAsync(string userName);
        Task<Account> GetAccountByIdAsync(string userName);
    }
}
