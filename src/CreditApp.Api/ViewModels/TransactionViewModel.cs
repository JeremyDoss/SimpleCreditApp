using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApp.Api.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Type { get; set; }
        public string TimeStamp { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
