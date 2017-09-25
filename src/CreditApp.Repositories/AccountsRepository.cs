using CreditApp.Entities;
using CreditApp.Infrastructure;
using CreditApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

                var userAccount = new Account
                {
                    UserName = userName,
                    Journals = new List<Journal>() {
                        new Journal {
                            Ledgers = new List<Ledger>() {
                                new Ledger {
                                    Type = "cash-out"
                                },
                                new Ledger {
                                    Type = "principal"
                                }
                            }
                        }
                    }
                };

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
                var account = await _context.Accounts.Include(a => a.Journals).FirstOrDefaultAsync(a => a.Id == userId);

                foreach (var journal in account.Journals)
                {
                    journal.Ledgers = _context.Ledgers
                        .Include(l => l.LedgerRecords)
                        .Where(l => l.JournalId == journal.Id).ToList();
                    journal.Transactions = _context.Transactions
                        .Where(t => t.JournalId == journal.Id)
                        .OrderBy(t => t.TimeStamp).ToList();
                }

                return account;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
