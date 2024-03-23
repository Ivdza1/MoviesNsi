using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesNsi.Infrastructure.Domain.Movie;

public class MovieConfiguration : IEntityTypeConfiguration<MoviesNsi.Domain.Entities.Movie>
{
    public void Configure(EntityTypeBuilder<MoviesNsi.Domain.Entities.Movie> builder)
    {
        builder.ToTable("Movies");
        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}