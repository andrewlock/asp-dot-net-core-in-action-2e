using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleRazorPagesApplicationAndHoldingPage
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseWelcomePage(); // Handles all requests
            app.UseExceptionHandler("/Error");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
