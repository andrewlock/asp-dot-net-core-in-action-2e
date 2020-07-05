using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FluentValidationConverter.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public string[] Currencies { get; set; }
        public string Results { get; set; }
        public IndexModel(ICurrencyProvider provider)
        {
            Currencies = provider.GetCurrencies();
        }

        public void OnGet()
        {
            Input = new InputModel
            {
                CurrencyFrom = "CAD",
                CurrencyTo = "USD",
                Quantity = 50
            };
        }
        
        public void OnPost()
        {
            Results = ModelState.IsValid
                ? $"Converting {Input.Quantity} {Input.CurrencyFrom} to {Input.CurrencyTo}"
                : "Please correct the errors";
        }


        public class InputModel
        {
            public string CurrencyFrom { get; set; }
            public string CurrencyTo { get; set; }
            public decimal Quantity { get; set; }
        }
        
        
        public class InputValidator : AbstractValidator<InputModel>
        {
            private readonly string[] _allowedValues = { "GBP", "USD", "CAD", "EUR" };
            public InputValidator(ICurrencyProvider provider)
            {
                RuleFor(x => x.CurrencyFrom)
                    .NotEmpty()
                    .Length(3)
                    .Must(value => _allowedValues.Contains(value))
                    .WithMessage("Not a valid currency code");

                RuleFor(x => x.CurrencyTo)
                    .NotEmpty()
                    .Length(3)
                    .MustBeCurrencyCode(provider)
                    .Must((InputModel model, string currencyTo)
                        => currencyTo != model.CurrencyFrom)
                    .WithMessage("Cannot convert currency to itself");


                RuleFor(x => x.Quantity)
                    .NotNull()
                    .InclusiveBetween(1, 1000);
            }
        }
    }
}
