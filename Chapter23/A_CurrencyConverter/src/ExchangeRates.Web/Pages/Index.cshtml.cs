using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CurrencySettings _settings;
        private readonly ICurrencyConverter _converter;

        public IndexModel(IOptions<CurrencySettings> settings, ICurrencyConverter converter)
        {
            _settings = settings.Value;
            _converter = converter;
        }

        [DisplayName("Value in alternate currency")]
        public decimal Result { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
            Input = new InputModel()
            {
                Value = _settings.DefaultValue,
                ExchangeRate = _settings.DefaultExchangeRate,
                DecimalPlaces = _settings.DefaultDecimalPlaces,
            };
        }

        public PageResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Result = _converter.ConvertToGbp(
                Input.Value,
                Input.ExchangeRate,
                Input.DecimalPlaces);

            return Page();
        }

        public class InputModel
        {
            [DisplayName("Value in GBP")]
            public decimal Value { get; set; } = 0;

            [DisplayName("Exchange rate from GBP to alternate currency")]
            [Range(0, double.MaxValue)]
            public decimal ExchangeRate { get; set; }

            [DisplayName("Round to decimal places")]
            [Range(0, int.MaxValue)]
            public int DecimalPlaces { get; set; }
        }
    }
}
