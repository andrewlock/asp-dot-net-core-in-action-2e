using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingDifferentEnvironments.Pages
{
    public class IndexModel : PageModel
    {
        public MyValues Values { get; }

        public IndexModel(IOptions<MyValues> values)
        {
            Values = values.Value;
        }

        public void OnGet()
        {

        }
    }
}
