using CustomEndpoint.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomEndpoint
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                // Build the pipeline in-line
                var endpoint = endpoints
                    .CreateApplicationBuilder()
                    .UseMiddleware<PingPongMiddleware>()
                    .Build();

                endpoints.Map("/pip-pip", endpoint);

                // See EndpointRouteBuilderExtensions for the definition of these methods
                endpoints.MapVersion("/version");
                endpoints.MapPingPong("/ping");

                //endpoints.MapGet("/ping", (HttpContext ctx) => 
                //    ctx.Response.WriteAsync("pong"));

                // Example of using route parameters in endpoint routes
                endpoints
                    .MapMiddleware<CalculatorMiddleware>("/add/{a}/{b}")
                    .WithDisplayName("Calculator");

                // Requires authorization (must be logged in)
                endpoints.MapHealthChecks("/healthz")
                    .RequireAuthorization();

                endpoints.MapGet("/isEven/{value:int}", context => {
                    int value = int.Parse((string)context.GetRouteValue("value"));
                    bool isEven = value % 2 == 0;
                    return context.Response.WriteAsync(isEven ? "even" : "odd");
                });

                endpoints.MapGet("/status", async context => {
                    var status = new { Running = true };
                    await context.Response.WriteAsJsonAsync(status);
                });

                endpoints.MapPost("/echo", async context => {
                    var json = await context.Request.ReadFromJsonAsync<MyCustomType>();
                    await context.Response.WriteAsJsonAsync(json);
                });
            });
        }
    }
    public class MyCustomType
    { }
}
