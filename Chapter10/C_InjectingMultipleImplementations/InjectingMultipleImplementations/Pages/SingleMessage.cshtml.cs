using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InjectingMultipleImplementations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InjectingMultipleImplementations.Pages
{
    public class SingleMessageModel : PageModel
    {
        private readonly IMessageSender _messageSender;
        public SingleMessageModel(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void OnGet(string username)
        {
            _messageSender.SendMessage(username);
        }
    }
}
