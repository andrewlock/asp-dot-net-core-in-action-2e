using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Airport.Pages.Airport
{
    [Authorize("CanEnterSecurity")]
    public class AirportSecurityModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}