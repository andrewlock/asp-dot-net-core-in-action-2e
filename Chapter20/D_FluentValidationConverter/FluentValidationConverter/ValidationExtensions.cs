using FluentValidation;
using System.Linq;

namespace FluentValidationConverter
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeCurrencyCode<T>(
            this IRuleBuilder<T, string> ruleBuilder, string[] allowedValues)
        {
            return ruleBuilder
                .Must(value => allowedValues.Contains(value))
                .WithMessage("Not a valid currency code");
        }

        public static IRuleBuilderOptions<T, string> MustBeCurrencyCode<T>(
            this IRuleBuilder<T, string> ruleBuilder, ICurrencyProvider currencyProvider)
        {
            return ruleBuilder
                .Must(value => currencyProvider.GetCurrencies().Contains(value))
                .WithMessage("Not a valid currency code");
        }
    }
}
