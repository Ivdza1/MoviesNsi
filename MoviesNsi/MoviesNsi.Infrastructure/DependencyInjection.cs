using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Domain.Entities;
using MoviesNsi.Infrastructure.Auth.Extensions;
using MoviesNsi.Infrastructure.Configuration;
using MoviesNsi.Infrastructure.Contexts;
using MoviesNsi.Infrastructure.Identity;
using MoviesNsi.Infrastructure.Services;

namespace MoviesNsi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            services.AddDbContext<MoviesNsiDbContext>(options =>
                options
                    .UseNpgsql(dbConfiguration.ConnectionString,
                        x =>
                            x.MigrationsAssembly(typeof(MoviesNsiDbContext).Assembly.FullName)));
        }

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddUserManager<ApplicationUserManager>()
            .AddEntityFrameworkStores<MoviesNsiDbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordlessLoginTokenProvider();

        services.AddScoped<IMoviesNsiDbContext>(provider => provider.GetRequiredService<MoviesNsiDbContext>());
        services.AddScoped<IActorService, ActorService>();
        services.AddScoped<IMovieService, MovieService>();
        
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        
        return services;
    }
}