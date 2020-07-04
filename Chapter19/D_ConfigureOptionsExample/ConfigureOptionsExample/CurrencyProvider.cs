namespace ConfigureOptionsExample
{
    public class CurrencyProvider : ICurrencyProvider
    {
        public string[] GetCurrencies()
        {
            // Load the settings from a database / remote API for example
            return new string[] { "GBP", "USD", "EUR", "CAD" };
        }
    }
}
