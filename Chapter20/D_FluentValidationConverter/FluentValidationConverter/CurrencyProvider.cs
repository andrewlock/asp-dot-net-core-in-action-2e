namespace FluentValidationConverter
{
    public class CurrencyProvider : ICurrencyProvider
    {
        public string[] GetCurrencies()
        {
            return new[] { "GBP", "USD", "CAD", "EUR" };
        }
    }
}