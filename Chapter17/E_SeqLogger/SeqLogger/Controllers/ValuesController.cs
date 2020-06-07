using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SeqLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        public readonly ILogger<ValuesController> _logger;
        public readonly ValuesService _service;
        public ValuesController(ILogger<ValuesController> logger, ValuesService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Inside controller, outside scope");

            using (_logger.BeginScope("Some scope value"))
            using (_logger.BeginScope(123))
            using (_logger.BeginScope(new Dictionary<string, object> { { "ScopeValue1", "outer scope" } }))
            {
                _logger.LogInformation("Inside controller, inside scope");
                return _service.GetValues();
            }
        }
    }
}
