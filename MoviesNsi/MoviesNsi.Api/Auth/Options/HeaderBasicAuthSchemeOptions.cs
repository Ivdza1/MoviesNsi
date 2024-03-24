using Microsoft.AspNetCore.Authentication;
using MoviesNsi.Application.Configuration;

namespace MoviesNsi.Auth.Options;

public class HeaderBasicAuthSchemeOptions : AuthenticationSchemeOptions
{
    public string UsernameHeader { get; set; } = "X-Mo-Username";
    public string PasswordHeader { get; set; } = "X-Mo-Password";

    public IEnumerable<HeaderBasicAuthConfiguration> Users { get; init; } = Array.Empty<HeaderBasicAuthConfiguration>();
}