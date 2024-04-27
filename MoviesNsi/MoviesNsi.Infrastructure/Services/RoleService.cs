using Microsoft.AspNetCore.Identity;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Infrastructure.Services;

public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{
    public async Task CreateRoleAsync(string role)
    {
        var alreadyExist = await roleManager.RoleExistsAsync(role);

        if (!alreadyExist)
        {
            await roleManager.CreateAsync(new ApplicationRole
            {
                Name = role,
                NormalizedName = role.Normalize()
            });
        }
    }
}