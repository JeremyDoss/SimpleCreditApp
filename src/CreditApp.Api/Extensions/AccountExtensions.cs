using CreditApp.Api.ViewModels;
using CreditApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApp.Api.Extensions
{
    public static class AccountExtensions
    {
        public static AccountViewModel ToAccountViewModel(this Account entity)
        {
            return new AccountViewModel
            {
                Id = entity.Id,
                Principal = GetAccountPrincipal(entity),
                Transactions = entity.Journals.FirstOrDefault()
                    .Transactions.Select(t => t.ToTransactionViewModel())//GetAccountTransactions(entity)
            };
        }

        private static double GetAccountPrincipal(Account account)
        {
            var principalLedgerRecords = account.Journals.FirstOrDefault().Ledgers
                .FirstOrDefault(l => l.Type == "principal").LedgerRecords;

            // Amount Used
            var principalCredit = principalLedgerRecords?.Where(r => r.Type == "credit").Sum(r => r.Amount);

            // Amount Paid
            var principalDebit = principalLedgerRecords?.Where(r => r.Type == "debit").Sum(r => r.Amount);

            return (principalCredit - principalDebit) ?? 0.00;
        }

        //private static IEnumerable<TransactionViewModel> GetAccountTransactions(Account account)
        //{
        //    var transactions = account.Journals.FirstOrDefault()
        //        .Transactions.OrderByDescending(t => t.TimeStamp)
        //        .Select(t => t.ToTransactionViewModel());

        //    return transactions;
        //}
    }
}
