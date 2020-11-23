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
    public class MultiMessageModel : PageModel
    {
        private readonly IEnumerable<IMessageSender> _messageSenders;
        public MultiMessageModel(IEnumerable<IMessageSender> messageSenders)
        {
            _messageSenders = messageSenders;
        }

        public void OnGet(string username)
        {
            foreach (var messageSender in _messageSenders)
            {
                messageSender.SendMessage(username);
            }
        }
    }
}
