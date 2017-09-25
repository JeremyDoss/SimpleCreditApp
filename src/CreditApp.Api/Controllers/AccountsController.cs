using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CreditApp.Infrastructure;
using CreditApp.Entities;
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

        // GET accounts
        [HttpGet]
        public async Task<IActionResult> CreateTestAccount()
        {
            var messages = await _accounts.CreateAccountAsync("test");

            return Ok(messages);
        }

        // GET accounts/5
        [HttpGet("{id}", Name = "GetAccount")]
        public IActionResult GetAccount(int id)
        {
            var account = new
            {
                Id = new Guid()
            };

            return Ok(account);
        }

        [HttpPost]
        //public async Task<IActionResult> CreateAccount()
        public IActionResult CreateAccount()
        {
            var account = new {
                Id = new Guid()
            };

            return CreatedAtRoute(routeName: "GetAccount", routeValues: new { id = account.Id }, value: account);
        }
    }
}
