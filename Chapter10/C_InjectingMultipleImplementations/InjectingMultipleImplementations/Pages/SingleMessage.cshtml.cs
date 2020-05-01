using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InjectingMultipleServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InjectingMultipleServices.Pages
{
    public class SingleMessageModel : PageModel
    {
        private readonly IMessageSender _messageSender;
        public SingleMessageModel(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void OnGet(string username, IMessageSender _messageSender)
        {
            _messageSender.SendMessage(username);
        }
    }
}
