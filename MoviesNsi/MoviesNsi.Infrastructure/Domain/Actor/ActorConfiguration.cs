using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesNsi.Infrastructure.Domain.Actor;

public class ActorConfiguration : IEntityTypeConfiguration<MoviesNsi.Domain.Entities.Actor>
{
    public void Configure(EntityTypeBuilder<MoviesNsi.Domain.Entities.Actor> builder)
    {
        builder.ToTable("Actors");
        builder.Property(x => x.Id);
        builder.Property<Guid>("MovieId");
        builder.HasIndex("MovieId");

        builder.HasOne(a => a.Movie)
            .WithMany(b => b.Actors)
            .HasForeignKey(a => a.MovieId)
            .IsRequired();
    }
}