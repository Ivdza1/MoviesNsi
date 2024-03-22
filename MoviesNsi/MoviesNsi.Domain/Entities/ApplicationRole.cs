using Microsoft.AspNetCore.Identity;

namespace MoviesNsi.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public IList<ApplicationUserRole> UserRoles { get; set; }
}