using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExchangeRates.Web.Tests
{
    /// <summary>
    /// These tests use the <see cref="CustomWebApplicationFactory"/> to centralise configuration. (See section 22.5.4)
    /// </summary>
    public class CustomWebApplicationFactoryTests: IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _fixture;
        public CustomWebApplicationFactoryTests(CustomWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ConvertReturnsExpectedValue()
        {
            HttpClient client = _fixture.CreateClient();

            // Act
            var response = await client.GetAsync("/api/currency");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("3", content);
        }

        [Fact]
        public async Task CanOverrideTestService()
        {
            var customFactory = _fixture.WithWebHostBuilder(hostBuilder =>
            {
                hostBuilder.ConfigureTestServices(services =>
                {
                    services.RemoveAll<ICurrencyConverter>();
                    services.AddSingleton<ICurrencyConverter, OtherCurrencyConverter>();
                });
            });

            HttpClient client = customFactory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/currency");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("5", content);
        }

        public class OtherCurrencyConverter : ICurrencyConverter
        {
            public decimal ConvertToGbp(decimal value, decimal rate, int dps) => 5;
        }
    }
}
