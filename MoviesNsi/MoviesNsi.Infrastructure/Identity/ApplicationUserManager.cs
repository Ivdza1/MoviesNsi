using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Infrastructure.Identity;

public class ApplicationUserManager(
    IUserStore<ApplicationUser> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<ApplicationUser> passwordHasher,
    IEnumerable<IUserValidator<ApplicationUser>> userValidators,
    IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<UserManager<ApplicationUser>> logger) : UserManager<ApplicationUser>(store,
    optionsAccessor,
    passwordHasher,
    userValidators,
    passwordValidators,
    keyNormalizer,
    errors,
    services,
    logger)
{
    //here, we can override identity functions
}