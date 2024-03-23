using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesNsi.Infrastructure.Domain.Identity;

public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    private const string AdminId = "4DAF65CB-CC0E-4C81-9183-20097EA81F5A";

    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        builder.ToTable("UserClaims");

        var adminIdClaim = new IdentityUserClaim<string>
        {
            UserId = AdminId,
            Id = 1,
            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
            ClaimValue = AdminId
        };

        var adminFirstName = new IdentityUserClaim<string>
        {
            UserId = AdminId,
            Id = 2,
            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname",
            ClaimValue = "Petar"
        };

        var adminLastName = new IdentityUserClaim<string>
        {
            UserId = AdminId,
            Id = 3,
            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname",
            ClaimValue = "Bisevac"
        };

        var adminEmail = new IdentityUserClaim<string>
        {
            UserId = AdminId,
            Id = 4,
            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress",
            ClaimValue = "pbisevac@singidunum.ac.rs"
        };

        var adminRoles = new IdentityUserClaim<string>
        {
            UserId = AdminId,
            Id = 5,
            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
            ClaimValue = "Administrator"
        };

        builder.HasData(adminFirstName, adminLastName, adminEmail, adminRoles, adminIdClaim);
    }
}