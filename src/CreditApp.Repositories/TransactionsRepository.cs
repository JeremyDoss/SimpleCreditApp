using CreditApp.Entities;
using CreditApp.Infrastructure;
using CreditApp.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApp.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly CreditDbContext _context;
        private readonly ILogger<TransactionsRepository> _logger;

        public TransactionsRepository(CreditDbContext context, ILogger<TransactionsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> RecordTransactionAsync(int userId, Transaction transaction)
        {

            try
            {
                var userJournal = _context.Accounts.FirstOrDefault(a => a.Id == userId).Journals.FirstOrDefault();

                if (userJournal == null)
                    throw new ArgumentException($"User ID {userId} was not found");

                // THIS
                transaction.JournalId = userJournal.Id;

                // OR
                //userJournal.Transactions.Add(transaction);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
