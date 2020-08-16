using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ExchangeRates.Web.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="StatusMiddleware"/> (See section 22.2)
    /// </summary>
    public class StatusMiddlewareTests
    {
        [Fact]
        public async Task ForMatchingRequest_ReturnsPlainTextType()
        {
            RequestDelegate next = (ctx) =>
            {
                ctx.Response.StatusCode = 404;
                return Task.CompletedTask;
            };

            var middleware = new StatusMiddleware(next: next);
            var context = new DefaultHttpContext();
            context.Request.Path = "/ping";

            await middleware.Invoke(context);

            Assert.Equal("text/plain", context.Response.ContentType);
        }

        [Fact]
        public async Task ForMatchingRequest_Returns200()
        {
            RequestDelegate next = (ctx) =>
            {
                ctx.Response.StatusCode = 404;
                return Task.CompletedTask;
            };

            var middleware = new StatusMiddleware(next: next);
            var context = new DefaultHttpContext();
            context.Request.Path = "/ping";

            await middleware.Invoke(context);

            Assert.Equal(200, context.Response.StatusCode);
        }


        [Fact]
        public async Task ForNonMatchingRequest_CallsNextDelegate()
        {
            var context = new DefaultHttpContext();
            context.Request.Path = "/somethingelse";

            var wasExecuted = false;
            RequestDelegate next = (ctx) =>
            {
                wasExecuted = true;
                return Task.CompletedTask;
            };
            var middleware = new StatusMiddleware(next: next);

            await middleware.Invoke(context);

            Assert.True(wasExecuted);
        }

        [Fact]
        public async Task ReturnsPlainTextType()
        {
            RequestDelegate next = (ctx) => Task.CompletedTask;
            var middleware = new StatusMiddleware(next: next);

            var context = new DefaultHttpContext();
            context.Request.Path = "/ping";
            await middleware.Invoke(context);

            Assert.Equal("text/plain", context.Response.ContentType);
        }

        [Fact]
        public async Task ReturnsPongBodyContent()
        {
            var bodyStream = new MemoryStream();
            var context = new DefaultHttpContext();
            context.Response.Body = bodyStream;
            context.Request.Path = "/ping";

            RequestDelegate next = (ctx) => Task.CompletedTask;
            var middleware = new StatusMiddleware(next: next);

            await middleware.Invoke(context);

            string response;
            bodyStream.Seek(0, SeekOrigin.Begin);
            using (var stringReader = new StreamReader(bodyStream))
            {
                response = await stringReader.ReadToEndAsync();
            }

            Assert.Equal("pong", response);
        }
    }
}
