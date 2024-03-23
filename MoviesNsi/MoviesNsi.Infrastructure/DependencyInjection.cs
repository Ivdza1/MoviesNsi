using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesNsi.Infrastructure.Configuration;
using MoviesNsi.Infrastructure.Contexts;

namespace MoviesNsi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        services.AddDbContext<MoviesNsiDbContext>(options =>
            options
                .UseNpgsql(dbConfiguration.ConnectionString,
                x =>
                    x.MigrationsAssembly(typeof(MoviesNsiDbContext).Assembly.FullName)));
        
        return services;
    }
}