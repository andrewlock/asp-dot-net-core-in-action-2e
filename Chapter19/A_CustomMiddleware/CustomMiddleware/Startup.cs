using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomMiddleware", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Uncomment to always return the time as plain text
            //app.Run(async (HttpContext context) =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync(DateTime.UtcNow.ToString());
            //});

            // Responds to /ping1
            app.Map("/ping1", (IApplicationBuilder branch) =>
            {
                branch.Run(async ctx =>
                {
                    ctx.Response.ContentType = "text/plain";
                    await ctx.Response.WriteAsync("pong");
                });
            });

            // Responds to /ping2
            app.Use(async (HttpContext context, Func<Task> next) =>
            {
                if (context.Request.Path.StartsWithSegments("/ping2"))
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("pong");
                }
                else
                {
                    await next();
                }
            });

            // Responds to /add?a=1&b=2
            app.UseCalculatorMiddleware();

            app.Map("/branch", branch =>
            {
                // Responds to /branch/ping
                branch.UsePingMiddleware();

                // Adds the X-Content-Type-Options:no sniff header
                branch.UseMiddleware<HeadersMiddleware>();
                // Responds to /branch
                branch.UseMiddleware<VersionMiddleware>();

            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // Responds to /weatherforecast
                endpoints.MapControllers();
            });
        }
    }
}
