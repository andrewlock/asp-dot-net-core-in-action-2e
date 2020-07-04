using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomEndpoint
{
    public class VersionMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly string _version = 
            FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).FileVersion;


        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var version = new { Version = _version };
            var content = JsonSerializer.Serialize(version);
            await context.Response.WriteAsync(content);
        }
    }
}
