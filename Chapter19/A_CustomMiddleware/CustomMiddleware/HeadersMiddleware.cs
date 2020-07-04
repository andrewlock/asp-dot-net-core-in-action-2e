using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    public class HeadersMiddleware
    {
        private readonly RequestDelegate _next;
        const int MaxAgeInSeconds = 60;

        public HeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
