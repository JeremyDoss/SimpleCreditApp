using System.ComponentModel.DataAnnotations;

namespace CreditApp.Api.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Type { get; set; }
        public string TimeStamp { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
