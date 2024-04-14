using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MoviesNsi.Infrastructure.Contexts;

namespace MoviesNsi.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // uklanjamo stari db context 
            services.RemoveAll<MoviesNsiDbContext>();

            var dbName = Guid.NewGuid().ToString();
            
            // dodajemo In-Memory db context
            services.AddDbContext<MoviesNsiDbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });
        });
    }
}