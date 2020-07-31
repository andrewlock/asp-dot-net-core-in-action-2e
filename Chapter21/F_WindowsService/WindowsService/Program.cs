using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using WindowsService.Data;

namespace WindowsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(hostContext.Configuration.GetConnectionString("SqlLiteConnection"))
                    );

                    services.AddHttpClient<ExchangeRatesClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://api.exchangeratesapi.io");
                        client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "ExchangeRateViewer");
                    });
                })
            .UseWindowsService();
    }
}
