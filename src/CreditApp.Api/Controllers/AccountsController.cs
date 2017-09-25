using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditApp.Repositories.Interfaces;

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
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                var account = await _accounts.GetAccountByIdAsync(id);

                if (account == null)
                    return NotFound();

                return Ok(account.Id);
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
                var newAccount = await _accounts.CreateAccountAsync(userName);

                return CreatedAtRoute(routeName: "GetAccount", routeValues: new { id = newAccount.Id }, value: newAccount);
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
