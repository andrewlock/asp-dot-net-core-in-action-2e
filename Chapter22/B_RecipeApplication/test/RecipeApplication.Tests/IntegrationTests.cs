using System.Threading.Tasks;
using Xunit;

namespace RecipeApplication.Tests
{
    public class IntegrationTests: IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _fixture;
        public IntegrationTests(CustomWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ViewIndexAsync()
        {
            var client = _fixture.CreateClient();

            var result = await client.GetAsync("/");

            result.EnsureSuccessStatusCode();
            var index = await result.Content.ReadAsStringAsync();
            Assert.Contains("<th>Recipe</th>", index);
        }
    }
}
