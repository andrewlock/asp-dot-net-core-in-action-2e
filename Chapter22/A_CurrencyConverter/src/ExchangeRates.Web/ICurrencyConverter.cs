namespace ExchangeRates.Web
{
    public interface ICurrencyConverter
    {
        decimal ConvertToGbp(decimal value, decimal exchangeRate, int decimalPlaces);
    }
}