using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace CustomEndpoint
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapVersion(this IEndpointRouteBuilder endpoints, string pattern)
        {
            var pipeline = endpoints.CreateApplicationBuilder()
                .UseMiddleware<VersionMiddleware>()
                .Build();

            return endpoints.Map(pattern, pipeline)
                .WithDisplayName("Version number");
        }

        public static IEndpointConventionBuilder MapPingPong(this IEndpointRouteBuilder endpoints, string pattern)
        {
            var pipeline = endpoints.CreateApplicationBuilder()
                .UseMiddleware<PingPongMiddleware>()
                .Build();

            return endpoints
                .Map(pattern, pipeline)
                .WithDisplayName("Ping-pong");
        }

        public static IEndpointConventionBuilder MapMiddleware<T>(this IEndpointRouteBuilder endpoints, string pattern)
        {
            var pipeline = endpoints.CreateApplicationBuilder()
                .UseMiddleware<T>()
                .Build();

            return endpoints.Map(pattern, pipeline);
        }
    }
}
