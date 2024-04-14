using Microsoft.Extensions.DependencyInjection;
using MoviesNsi.Infrastructure.Contexts;
using Xunit;

namespace MoviesNsi.FunctionalTests
{
    public class BaseTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public readonly HttpClient Client;
        public readonly MoviesNsiDbContext MoviesNsiDbContext;

        public BaseTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            Client = factory.CreateClient();
            var scope = factory.Services.CreateScope();
            MoviesNsiDbContext = scope.ServiceProvider.GetRequiredService<MoviesNsiDbContext>();
        }
    }
}