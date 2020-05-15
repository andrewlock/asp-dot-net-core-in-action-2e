using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterPipelineExample.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FilterPipelineExample
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
            services.AddRazorPages();
            services.AddControllers(options =>
            {
                options.Filters.Add(new GlobalLogAsyncActionFilter()); // won't apply to page
                options.Filters.Add(new GlobalLogAsyncPageFilter()); // won't apply to action
                options.Filters.Add(new GlobalLogAsyncAuthorizationFilter());
                options.Filters.Add(new GlobalLogAsyncExceptionFilter());
                options.Filters.Add(new GlobalLogAsyncResourceFilter());
                options.Filters.Add(new GlobalLogAsyncResultFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
