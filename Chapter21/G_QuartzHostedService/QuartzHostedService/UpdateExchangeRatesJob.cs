using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using QuartzHostedService.Data;

namespace QuartzHostedService
{
    [DisallowConcurrentExecution]
    public class UpdateExchangeRatesJob : IJob
    {
        private readonly ILogger<UpdateExchangeRatesJob> _logger;
        private readonly ExchangeRatesClient _httpClient;
        private readonly AppDbContext _dbContext;
        public UpdateExchangeRatesJob(ILogger<UpdateExchangeRatesJob> logger, ExchangeRatesClient httpClient, AppDbContext dbContext)
        {
            _logger = logger;
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Fetching latest rates");

            var latestRates = await _httpClient.GetLatestRatesAsync();

            _dbContext.Add(latestRates);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Latest rates updated");
        }
    }

}
