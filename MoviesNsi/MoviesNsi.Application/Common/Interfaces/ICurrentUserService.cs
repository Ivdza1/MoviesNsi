namespace MoviesNsi.Application.Common.Interfaces;

public interface ICurrentUserService
{
    public string? UserId { get; }
    public string? FirstName { get; }
    public string? LastName { get; }
    public string? Email { get; }
    public List<string>? Roles { get; }
    bool IsAdministrator { get; }
}