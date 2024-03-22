using Microsoft.AspNetCore.Identity;

namespace MoviesNsi.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public IList<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
}