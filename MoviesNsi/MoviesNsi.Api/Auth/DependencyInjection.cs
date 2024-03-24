using MoviesNsi.Auth.Constants;
using MoviesNsi.Auth.Options;
using MoviesNsi.Auth.Schemes;

namespace MoviesNsi.Auth;

public static class DependencyInjection
{
    
    // webhook auth?
    public static IServiceCollection AddMoviesNsiAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthSchemeOptions, HeaderBasicAuthSchemeHandler>(
                AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header")
                    .Bind(schemeOptions));

        return services;
    }
}