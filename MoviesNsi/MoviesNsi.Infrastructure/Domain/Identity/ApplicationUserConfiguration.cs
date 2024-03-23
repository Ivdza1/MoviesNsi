using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Infrastructure.Domain.Identity;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    private const string AdminId = "4DAF65CB-CC0E-4C81-9183-20097EA81F5A";

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        var admin = new ApplicationUser
        {
            Id = AdminId,
            UserName = "ivan.popovic.20@singimail.rs",
            NormalizedUserName = "IVAN.POPOVIC.20@SINGIMAIL.RS",
            Email = "ivan.popovic.20@singimail.rs",
            NormalizedEmail = "IVAN.POPOVIC.20@SINGIMAIL.RS",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = new Guid().ToString("D"),
            FirstName = "Ivan",
            LastName = "Popovic",
            ConcurrencyStamp = "c188a435-cfc8-45fd-836c-9a18bb9de405",
            AccessFailedCount =  0
        };

        builder.HasData(admin);

        builder.HasMany(x => x.Roles).WithOne()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}