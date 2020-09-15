using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuartzClustering
{
    public class ExchangeRatesClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ExchangeRatesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeRates> GetLatestRatesAsync()
        {
            var rates = await _httpClient.GetFromJsonAsync<ExchangeRateDto>("latest", _serializerOptions);
            return rates.ToRates();
        }

        public class ExchangeRateDto
        {
            public string Base { get; set; }
            public string Date { get; set; }
            public Dictionary<string, decimal> Rates { get; set; }

            public ExchangeRates ToRates()
            {
                return new ExchangeRates
                {
                    Base = this.Base,
                    Date = this.Date,
                    Rates = this.Rates
                        .Select(pair => new ExchangeRateValues
                        {
                            Rate = pair.Key,
                            Value = pair.Value,
                        })
                        .ToList(),
                };
            }
        }
    }
}
