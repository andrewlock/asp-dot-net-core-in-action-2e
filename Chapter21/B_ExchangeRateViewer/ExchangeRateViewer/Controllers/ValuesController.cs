using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace ExchangeRateViewer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ExchangeRatesClient _ratesClient;
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.exchangeratesapi.io"),
        };
        public ValuesController(IHttpClientFactory clientFactory, ExchangeRatesClient ratesClient)
        {
            _clientFactory = clientFactory;
            _ratesClient = ratesClient;
        }

        [HttpGet("httpclient")]
        public async Task<ActionResult<ExchangeRates>> HttpClientAsync()
        {
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "ExchangeRateViewer");
            var result = await _httpClient.GetAsync("latest");
            result.EnsureSuccessStatusCode();

            // Return results as json.
            var stream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ExchangeRates>(stream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        [HttpGet("httpclientfactory")]
        public async Task<ActionResult<ExchangeRates>> HttpClientFactoryAsync()
        {
            var httpClient = _clientFactory.CreateClient();
            
            httpClient.BaseAddress = new Uri("https://api.exchangeratesapi.io");
            httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "ExchangeRateViewer");

            var result = await httpClient.GetAsync("latest");
            result.EnsureSuccessStatusCode();

            var stream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ExchangeRates>(stream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        [HttpGet("namedclient")]
        public async Task<ActionResult<ExchangeRates>> NamedClientAsync()
        {
            var httpClient = _clientFactory.CreateClient("rates");

            var result = await httpClient.GetAsync("latest");
            result.EnsureSuccessStatusCode();

            var stream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ExchangeRates>(stream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        [HttpGet("typedclient")]
        public async Task<ActionResult<ExchangeRates>> TypedClientAsync()
        {
            return await _ratesClient.GetLatestRatesAsync();
        }
    }
}
