using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceCache
{
    public class ExchangeRatesHostedService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly ExchangeRatesCache _cache;
        private readonly TimeSpan _refreshInterval = TimeSpan.FromMinutes(5);
        private readonly ILogger<ExchangeRatesHostedService> _logger;

        public ExchangeRatesHostedService(
            ExchangeRatesCache cache,
            IServiceProvider provider,
            ILogger<ExchangeRatesHostedService> logger)
        {
            _cache = cache;
            _provider = provider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Fetching latest rates");
                var client = _provider.GetRequiredService<ExchangeRatesClient>();
                var latest = await client.GetLatestRatesAsync();
                _cache.SetRates(latest);
                _logger.LogInformation("Latest rates updated");

                await Task.Delay(_refreshInterval, stoppingToken);
            }
        }
    }
}
