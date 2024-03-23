using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesNsi.Infrastructure.Domain.Actor;

public class ActorConfiguration : IEntityTypeConfiguration<MoviesNsi.Domain.Entities.Actor>
{
    public void Configure(EntityTypeBuilder<MoviesNsi.Domain.Entities.Actor> builder)
    {
        builder.ToTable("Actors");
    }
}