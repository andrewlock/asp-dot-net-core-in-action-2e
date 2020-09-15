using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Quartz;
using QuartzHostedService.Data;

namespace QuartzHostedService
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
                    var connectionString = hostContext.Configuration.GetConnectionString("SqlLiteConnection");
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(connectionString)
                    );

                    services.AddHttpClient<ExchangeRatesClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://api.exchangeratesapi.io");
                        client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "ExchangeRateViewer");
                    });

                    services.AddQuartz(q =>
                    {
                        // Normally would take this from appsettings.json, just show it's possible
                        q.SchedulerName = "Example Quartz Scheduler";

                        // Use a Scoped container for creating IJobs
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();

                        q.UseSimpleTypeLoader();

                        // add the job
                        var jobKey = new JobKey("Update exchange rates");
                        q.AddJob<UpdateExchangeRatesJob>(opts => opts.WithIdentity(jobKey));
                        q.AddTrigger(opts => opts
                            .ForJob(jobKey)
                            .StartNow()
                            .WithSimpleSchedule(x => x
                                .WithInterval(TimeSpan.FromMinutes(5))
                                .RepeatForever())
                        );
                    });
                    services.AddQuartzServer(q => q.WaitForJobsToComplete = true);
                });
    }
}
