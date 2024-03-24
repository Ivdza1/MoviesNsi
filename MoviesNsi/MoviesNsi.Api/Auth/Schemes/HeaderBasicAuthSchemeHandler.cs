using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using MoviesNsi.Auth.Options;

namespace MoviesNsi.Auth.Schemes;

public class HeaderBasicAuthSchemeHandler : AuthenticationHandler<HeaderBasicAuthSchemeOptions>
{
    [Obsolete("Obsolete")]
    public HeaderBasicAuthSchemeHandler(IOptionsMonitor<HeaderBasicAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    public HeaderBasicAuthSchemeHandler(IOptionsMonitor<HeaderBasicAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var username = Request.Headers[Options.UsernameHeader].FirstOrDefault() ??
                              throw new InvalidOperationException("Missing username header");
            
            var password = Request.Headers[Options.PasswordHeader].FirstOrDefault() ??
                              throw new InvalidOperationException("Missing password header");
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