using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListBinding.Pages
{
    public class IndexModel : PageModel
    {
        public List<SelectListItem> Currencies { get; set; }

        public void OnGet()
        {
            Currencies = CurrencyService.AllCurrencies
                .Select(x => new SelectListItem { Text = x.Key })
                .ToList();
        }
    }
}
