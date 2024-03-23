using Microsoft.EntityFrameworkCore;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Application.Common.Interfaces;

public interface IMoviesNsiDbContext
{
    public DbSet<Domain.Entities.Actor> Actors { get; }
    
    public DbSet<Movie> Movies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}