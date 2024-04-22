using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesNsi.Domain.Enums;

namespace MoviesNsi.Infrastructure.Domain.Movie;

public class MovieConfiguration : IEntityTypeConfiguration<MoviesNsi.Domain.Entities.Movie>
{
    public void Configure(EntityTypeBuilder<MoviesNsi.Domain.Entities.Movie> builder)
    {
        builder.ToTable("Movies");
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(b => b.Category)
            .IsRequired()
            .HasDefaultValue(Category.Thriller)
            .HasConversion(p => p.Value, p => Category.FromValue(p));
    }
}