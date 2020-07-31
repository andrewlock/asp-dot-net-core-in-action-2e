using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ExchangeRatesCache _cache;

        public ValuesController(ExchangeRatesCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public ActionResult<ExchangeRates> TypedClient()
        {
            return _cache.GetLatestRates();
        }
    }
}
