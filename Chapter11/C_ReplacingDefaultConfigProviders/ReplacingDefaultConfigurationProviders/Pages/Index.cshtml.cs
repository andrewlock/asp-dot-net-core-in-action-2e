using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplacingDefaultConfigurationProviders.Pages
{
    public class IndexModel : PageModel
    {
        public IConfiguration Config { get; }

        public IndexModel(IConfiguration config)
        {
            Config = config;
        }

        public void OnGet()
        {

        }
    }
}
