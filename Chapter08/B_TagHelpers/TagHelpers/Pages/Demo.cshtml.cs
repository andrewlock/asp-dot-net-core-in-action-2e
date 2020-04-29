using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TagHelpers.Pages
{
    public class DemoModel : PageModel
    {
        public int Int { get; set; }
        public bool Boolean { get; set; }
        public DateTime? DateTime { get; set; }
        public void OnGet()
        {

        }
    }
}