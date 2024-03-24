using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Auth.Options;

namespace MoviesNsi.Auth.Schemes;

public class HeaderBasicAuthSchemeHandler : AuthenticationHandler<HeaderBasicAuthSchemeOptions>
{
    private readonly IMoviesNsiDbContext _dbContext;
    [Obsolete("Obsolete")]
    public HeaderBasicAuthSchemeHandler(IOptionsMonitor<HeaderBasicAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IMoviesNsiDbContext dbContext) : base(options, logger, encoder, clock)
    {
        _dbContext = dbContext;
    }

    public HeaderBasicAuthSchemeHandler(IOptionsMonitor<HeaderBasicAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IMoviesNsiDbContext dbContext) : base(options, logger, encoder)
    {
        _dbContext = dbContext;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var username = Request.Headers[Options.UsernameHeader].FirstOrDefault() ??
                              throw new InvalidOperationException("Missing username header");
            
            var password = Request.Headers[Options.PasswordHeader].FirstOrDefault() ??
                              throw new InvalidOperationException("Missing password header");

            var movies = await _dbContext.Movies.ToListAsync();
            
            var user = Options.Users.SingleOrDefault(user =>
                           user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                           user.Password.Equals(password, StringComparison.OrdinalIgnoreCase)) ??
                       throw new InvalidOperationException("Invalid username or password.");

            var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, username) };
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
            claims.AddRange(user.Claims.Select(x => new Claim(x.Key, x.Value)));

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Tokens"));
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            
            return AuthenticateResult.Success(ticket);

        }

        catch (Exception e)
        {
            return AuthenticateResult.Fail("Unauthorized.");
        }
    }
}