using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditApp.Repositories.Interfaces;
using CreditApp.Api.Extensions;

namespace CreditApp.Api.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsRepository _accounts;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger, IAccountsRepository accounts)
        {
            _accounts = accounts;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(string userName)
        {
            try
            {
                _logger.LogTrace("Accounts controller GetAccount");

                var account = await _accounts.GetAccountByIdAsync(userName);

                if (account == null)
                    return NotFound();

                return Ok(account.ToAccountViewModel());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] string userName)
        {
            try
            {
                _logger.LogTrace("Accounts controller CreateAccount");

                var newAccount = await _accounts.CreateAccountAsync(userName);

                return Ok(value: new { newAccount.Id });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
