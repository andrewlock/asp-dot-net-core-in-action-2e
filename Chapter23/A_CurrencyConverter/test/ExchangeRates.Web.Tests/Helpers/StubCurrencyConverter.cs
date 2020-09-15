namespace ExchangeRates.Web.Tests
{
    public class StubCurrencyConverter : ICurrencyConverter
    {
        public decimal ConvertToGbp(decimal value, decimal rate, int dps)
        {
            return 3;
        }
    }
}
