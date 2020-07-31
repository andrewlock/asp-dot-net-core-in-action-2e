using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SystemdService.Data;

namespace SystemdService
{
    public class ExchangeRatesHostedService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly TimeSpan _refreshInterval = TimeSpan.FromMinutes(5);
        private readonly ILogger<ExchangeRatesHostedService> _logger;

        public ExchangeRatesHostedService(
            IServiceProvider provider,
            ILogger<ExchangeRatesHostedService> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _provider.CreateScope())
                {
                    _logger.LogInformation("Fetching latest rates");
                    var client = _provider.GetRequiredService<ExchangeRatesClient>();
                    var latestRates = await client.GetLatestRatesAsync();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    context.Add(latestRates);
                    await context.SaveChangesAsync();
                    _logger.LogInformation("Latest rates updated");
                }
                await Task.Delay(_refreshInterval, stoppingToken);
            }
        }
    }
}
