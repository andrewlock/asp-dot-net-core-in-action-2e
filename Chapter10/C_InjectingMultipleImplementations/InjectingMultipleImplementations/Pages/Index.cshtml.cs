using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InjectingMultipleServices.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<MultiMessageModel> _logger;

        public IndexModel(ILogger<MultiMessageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
