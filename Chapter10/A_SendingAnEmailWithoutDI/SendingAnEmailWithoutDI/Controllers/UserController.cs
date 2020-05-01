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
        [Route("register")]
        public IActionResult RegisterUser(string username)
        {
            var emailSender = new EmailSender(
                new MessageFactory(),
                new NetworkClient(
                    new EmailServerSettings
                    {
                        Host = "smtp.server.com",
                        Port = 25
                    })
                );
            emailSender.SendEmail(username);
            return Ok("Email sent!");
        }
    }
}
