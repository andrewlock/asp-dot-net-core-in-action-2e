using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceCache
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
            return await _httpClient.GetFromJsonAsync<ExchangeRates>("latest", _serializerOptions);
        }
    }
}
