using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundServiceDatabaseCache.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceDatabaseCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ValuesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ExchangeRates>> TypedClientAsync()
        {
            return await _context.ExchangeRates
                .Include(rates => rates.Rates)
                .OrderByDescending(rates => rates.ExchangeRatesId)
                .FirstOrDefaultAsync();
        }
    }
}
