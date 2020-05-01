using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LifetimeExamples
{
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseDefaultServiceProvider(options =>
            {
                // set the value to true to always validate scopes,
                // or use the alternative definition below (the default) to only
                // validate in dev environments only for performance reasons
                options.ValidateScopes = false;
                options.ValidateOnBuild = false;
            });
            //.UseDefaultServiceProvider((ctx, options) =>
            //{
            //    options.ValidateScopes = ctx.HostingEnvironment.IsDevelopment();
            //    options.ValidateOnBuild = ctx.HostingEnvironment.IsDevelopment();

            //})
    }
}
