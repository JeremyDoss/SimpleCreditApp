using CreditApp.Api.ViewModels;
using CreditApp.Entities;

namespace CreditApp.Api.Extensions
{
    public static class TransactionExtensions
    {
        public static TransactionViewModel ToTransactionViewModel(this Transaction entity)
        {
            return new TransactionViewModel
            {
                Id = entity.Id,
                Type = entity.Type,
                Amount = entity.Amount,
                TimeStamp = entity.TimeStamp.ToString()
            };
        }

        public static Transaction ToTransaction(this TransactionViewModel vm)
        {
            return new Transaction
            {
                Type = vm.Type,
                Amount = vm.Amount,
            };
        }
    }
}
