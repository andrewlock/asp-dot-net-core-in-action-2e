using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CurrencyConverter
{
    public class CurrencyCodeWithDiAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext context)
        {
            var code = value as string;
            var provider = context.GetRequiredService<ICurrencyProvider>();
            var allowedCodes = provider.GetCurrencies();

            if (code == null || !allowedCodes.Contains(code))
            {
                return new ValidationResult("Not a valid currency code");
            }

            return ValidationResult.Success;
        }
    }
}