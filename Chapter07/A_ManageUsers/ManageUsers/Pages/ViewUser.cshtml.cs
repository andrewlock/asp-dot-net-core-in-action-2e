using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ManageUsers.Pages
{
    public class ViewUserModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        public void OnGet()
        {
        }

    }
}
