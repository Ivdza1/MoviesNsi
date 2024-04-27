using System.Security.Authentication;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Domain.Entities;
using MoviesNsi.Infrastructure.Exceptions;

namespace MoviesNsi.Infrastructure.Identity;

public class UserService(ApplicationUserManager userManager) : IUserService 
{
    public async Task CreateUserAsync(string emailAdress, List<string> roles)
    {
        var alreadyExist = await userManager.FindByEmailAsync(emailAdress);

        if (alreadyExist != null)
            return;

        var user = new ApplicationUser
        {
            Email = emailAdress,
            UserName = emailAdress
        };

        try
        {
            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new AuthException("Could not create a new user",
                    new { Errors = result.Errors.ToList() });
            }

            var rolesResult = await userManager.AddToRolesAsync(user,
                roles.Select(nr => nr.ToUpper()));

            if (!rolesResult.Succeeded)
            {
                await userManager.DeleteAsync(user);

                throw new AuthException("Could not add roles to user",
                    new { Errors = rolesResult.Errors.ToList() });
            }
        }
        catch (Exception e)
        {
            await userManager.DeleteAsync(user);

            throw new AuthException("Could not create a new user",
                e);
        }
    }
    public Task<ApplicationUser?> GetUserAsync(string id) => userManager.FindByIdAsync(id);
    public Task<ApplicationUser?> GetUserByEmailAsync(string id) => userManager.FindByEmailAsync(id);
    public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName) => userManager.IsInRoleAsync(user,
        roleName);
    }
