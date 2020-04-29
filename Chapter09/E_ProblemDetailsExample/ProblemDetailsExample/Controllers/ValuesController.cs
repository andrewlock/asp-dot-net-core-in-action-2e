using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProblemDetailsExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet("{myValue?}")]
        public IActionResult Get([Required] string myValue)
        {
            // Never called, due to automatic invalid response generation
            return Ok(myValue);
        }
    }
}
