using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesigningForAutomaticBinding.Pages
{
    public class IndexModel : PageModel
    {
        public TestOptions Options { get; }
        public IndexModel(IOptions<TestOptions> options)
        {
            Options = options.Value;
        }

        public void OnGet()
        {

        }
    }
}
