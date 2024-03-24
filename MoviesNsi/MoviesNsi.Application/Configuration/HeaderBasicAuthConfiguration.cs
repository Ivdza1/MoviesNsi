namespace MoviesNsi.Application.Configuration;

public class HeaderBasicAuthConfiguration
{
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string[] Roles { get; init; } = Array.Empty<string>();
    public Dictionary<string, string> Claims { get; init; } = new Dictionary<string, string>();
}