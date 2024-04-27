using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(string emailAdress, List<string> roles);
    Task<ApplicationUser?> GetUserAsync(string id);
    Task<ApplicationUser?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
}