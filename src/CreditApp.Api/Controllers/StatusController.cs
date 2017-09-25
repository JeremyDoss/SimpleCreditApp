using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CreditApp.Api.Controllers
{
    [Route("health")]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetHealth()
        {
            _logger.LogInformation("The credit service is up and running.");

            return Ok();
        }
    }
}
