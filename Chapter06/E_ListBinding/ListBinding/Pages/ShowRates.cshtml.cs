using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListBinding.Pages
{
    public class ShowRatesModel : PageModel
    {
        public Dictionary<string, decimal> SelectedCurrencies { get; set; }

        public void OnPost(List<string> currencies)
        {
            SelectedCurrencies =
                CurrencyService.AllCurrencies
                .Where(x => currencies.Contains(x.Key))
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}