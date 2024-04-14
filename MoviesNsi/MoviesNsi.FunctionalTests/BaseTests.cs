using Microsoft.Extensions.DependencyInjection;
using Moq;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Infrastructure.Contexts;
using Xunit;

namespace MoviesNsi.FunctionalTests
{
    public class BaseTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public readonly HttpClient Client;
        public readonly MoviesNsiDbContext MoviesNsiDbContext;
        public readonly Mock<IMovieService> MockMovieService;

        public BaseTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            Client = factory.CreateClient();
            var scope = factory.Services.CreateScope();
            MoviesNsiDbContext = scope.ServiceProvider.GetRequiredService<MoviesNsiDbContext>();
            MockMovieService = factory.MockMovieService;
        }
    }
}