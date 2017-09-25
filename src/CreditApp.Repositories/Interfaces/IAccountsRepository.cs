using CreditApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<Account> CreateAccountAsync(string userName);
        Task<Account> GetAccountByIdAsync(int userId);
    }
}
