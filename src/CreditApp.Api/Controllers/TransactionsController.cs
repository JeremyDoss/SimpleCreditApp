using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditApp.Repositories.Interfaces;
using CreditApp.Api.ViewModels;
using CreditApp.Api.Extensions;

namespace CreditApp.Api.Controllers
{
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionsRepository _transactions;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger, ITransactionsRepository transactions)
        {
            _transactions = transactions;
            _logger = logger;
        }

        public async Task<IActionResult> PostTransaction([FromBody] int userId, [FromBody] TransactionViewModel transaction)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _transactions.RecordTransactionAsync(userId, transaction.ToTransaction());

                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
