using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplacingDefaultConfigurationProviders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddAppConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void AddAppConfiguration(
            HostBuilderContext hostingContext,
            IConfigurationBuilder config)
        {
            config.Sources.Clear();
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config.AddJsonFile("extrasettings.json", optional: false, reloadOnChange: true);
        }
    }
}
