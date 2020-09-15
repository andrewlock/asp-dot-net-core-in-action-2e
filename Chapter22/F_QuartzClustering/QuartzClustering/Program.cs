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
using QuartzClustering.Data;

namespace QuartzClustering
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
                    var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString)
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
                        q.SchedulerId = "AUTO";

                        // Use a Scoped container for creating IJobs
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();

                        q.UseSimpleTypeLoader();

                        q.UsePersistentStore(s =>
                        {
                            s.UseSqlServer(connectionString);
                            s.UseClustering();
                            s.UseProperties = true;
                            s.UseJsonSerializer();
                        });

                        // add the job
                        var jobKey = new JobKey("Update_exchange_rates");

                        q.AddJob<UpdateExchangeRatesJob>(opts => opts.WithIdentity(jobKey));

                        // Run every day, at 3am
                        //q.AddTrigger(opts => opts
                        //    .ForJob(jobKey)
                        //    .WithIdentity(jobKey.Name + "_trigger")
                        //    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(hour: 3, 0))
                        //);

                        // Run every 1 minute
                        q.AddTrigger(opts => opts
                            .ForJob(jobKey)
                            .WithIdentity(jobKey.Name + "_trigger") // Important, 
                            .WithSimpleSchedule(x => x
                                .WithIntervalInMinutes(1)
                                .RepeatForever()
                            )
                        );
                    });
                    services.AddQuartzServer(q => q.WaitForJobsToComplete = true);
                });
    }
}
