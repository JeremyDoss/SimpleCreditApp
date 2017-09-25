using CreditApp.Entities;
using CreditApp.Infrastructure;
using CreditApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApp.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly CreditDbContext _context;
        private readonly ILogger<AccountsRepository> _logger;

        public AccountsRepository(CreditDbContext context, ILogger<AccountsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Account> CreateAccountAsync(string userName)
        {
            try
            {
                if (_context.Accounts.Any(a => a.UserName == userName))
                    throw new ArgumentException($"The user name '{userName}' is already taken.");

                var userAccount = new Account(userName);

                 _context.Add(userAccount);

                await _context.SaveChangesAsync();

                return userAccount;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Account> GetAccountByIdAsync(int userId)
        {
            try
            {
                return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
