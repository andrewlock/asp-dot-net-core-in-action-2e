using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRateViewer
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {
        private readonly ExchangeRateApiSettings _settings;

        public ApiKeyMessageHandler(IOptions<ExchangeRateApiSettings> settings)
        {
            _settings = settings.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-API-KEY", _settings.ApiKey);

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
