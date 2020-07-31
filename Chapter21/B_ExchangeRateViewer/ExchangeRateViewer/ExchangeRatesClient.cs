using Microsoft.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeRateViewer
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
            _httpClient.BaseAddress = new Uri("https://api.exchangeratesapi.io");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "ExchangeRateViewer");
        }

        public async Task<ExchangeRates> GetLatestRatesAsync()
        {
            var result = await _httpClient.GetAsync("latest");
            result.EnsureSuccessStatusCode();

            var stream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ExchangeRates>(stream, _serializerOptions);

            // or, using System.Net.Http.Json

            //return await _httpClient.GetFromJsonAsync<ExchangeRates>("latest", _serializerOptions);
        }
    }
}
