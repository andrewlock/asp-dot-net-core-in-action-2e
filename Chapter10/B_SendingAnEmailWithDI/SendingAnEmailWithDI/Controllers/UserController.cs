using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendingAnEmailWithoutDI.Services;

namespace SendingAnEmailWithoutDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public UserController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [Route("register")]
        public IActionResult RegisterUser(string username)
        {
            _emailSender.SendEmail(username);
            return Ok("Email sent!");
        }
    }
}
