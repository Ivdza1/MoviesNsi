using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoviesNsi.Infrastructure.Auth.Options;

namespace MoviesNsi.Infrastructure.Auth.Providers;

public class PasswordlessLoginTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
    public PasswordlessLoginTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<PasswordlessLoginTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<TUser>> logger) : base(dataProtectionProvider,
        options,
        logger)
    {
    }
}