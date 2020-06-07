using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SeqLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScopesController : Controller
    {
        public readonly ILogger<ScopesController> _logger;
        public ScopesController(ILogger<ScopesController> logger)
        {
            _logger = logger;
        }

        // GET api/scopes
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("No, I don’t have scope");

            using (_logger.BeginScope("Scope value"))
            using (_logger.BeginScope(new Dictionary<string, object> { { "CustomValue1", 12345 } }))
            {
                _logger.LogInformation("Yes, I have the scope!");
            }

            _logger.LogInformation("No, I lost it again");

            return Ok();
        }
    }
}
