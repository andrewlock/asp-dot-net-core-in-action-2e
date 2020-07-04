using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UsePingMiddleware(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/ping"))
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("pong");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        public static IApplicationBuilder UseCalculatorMiddleware(this IApplicationBuilder app)
        {
            return app.Map("/add", branch =>
            {
                branch.Run(async context =>
                {
                    var query = context.Request.Query;
                    if (int.TryParse(query["a"], out int a) &&
                       int.TryParse(query["b"], out int b))
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync($"{a} + {b} = {a + b}");
                    }
                    else
                    {
                        //bad request
                        context.Response.StatusCode = 400;
                    }
                });
            });
        }
    }
}
