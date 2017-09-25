﻿using CreditApp.Entities;
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

                transaction.JournalId = userJournal.Id;

                RecordLedgerRecordAsync(userJournal, transaction);

                _context.Transactions.Add(transaction);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void RecordLedgerRecordAsync(Journal journal, Transaction transaction)
        {
            var cashOutLedgerRecord = new LedgerRecord {
                LedgerId = journal.Ledgers.FirstOrDefault(l => l.Type == "cash-out").Id,
                TransactionId = transaction.Id,
                Amount = transaction.Amount,
                TimeStamp = transaction.TimeStamp
            };

            var principalLedgerRecord = new LedgerRecord
            {
                LedgerId = journal.Ledgers.FirstOrDefault(l => l.Type == "principal").Id,
                TransactionId = transaction.Id,
                Amount = transaction.Amount,
                TimeStamp = transaction.TimeStamp
            };

            switch (transaction.Type.ToLower())
            {
                case "purchase":
                    cashOutLedgerRecord.Type = "debit";
                    principalLedgerRecord.Type = "credit";
                    break;
                case "payment":
                    cashOutLedgerRecord.Type = "credit";
                    principalLedgerRecord.Type = "debit";
                    break;
                default:
                    throw new ArgumentException("Unknown transaction type");
            }

            _context.LedgerRecords.Add(cashOutLedgerRecord);
            _context.LedgerRecords.Add(principalLedgerRecord);
        }
    }
}
