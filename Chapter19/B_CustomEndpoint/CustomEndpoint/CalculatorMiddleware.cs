using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CustomEndpoint
{
    public class CalculatorMiddleware
    {
        public CalculatorMiddleware(RequestDelegate next)
        {
        }

        public async Task Invoke(HttpContext context)
        {
            // see https://andrewlock.net/accessing-route-values-in-endpoint-middleware-in-aspnetcore-3/ for 
            // a more robust solution
            var aValue = context.GetRouteValue("a") as string;
            var bValue = context.GetRouteValue("b") as string;

            var a = int.Parse(aValue);
            var b = int.Parse(bValue);

            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync($"{a} + {b} = {a + b}");
        }
    }
}