using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Application.Exceptions;

namespace MoviesNsi.Infrastructure.Services;

public class ActorService(IMoviesNsiDbContext dbContext, IMovieService movieService) : IActorService
{
    public async Task<ActorInfoDto> CreateAsync(ActorCreateDto actor, CancellationToken cancellationToken)
    {
        var test = movieService.CreateAsync();
        
        var movie = await dbContext.Movies
            .Where(x => x.Id == actor.MovieId)
            .FirstOrDefaultAsync(cancellationToken);

        if (movie == null)
            throw new NotFoundException("Movie not found.");

        var actorEntity = actor.FromCreateDtoToEntity().AddMovie(movie);

        dbContext.Actors.Add(actorEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return actorEntity.ToDto();
    }
    

    public async Task<ActorInfoDto> UpdateAsync(Guid actorId, ActorUpdateDto actor, CancellationToken cancellationToken)
    {
        var actorEntity = await dbContext.Actors
            .Where(a => a.Id == actorId)
            .FirstOrDefaultAsync(cancellationToken);

        if (actorEntity == null)
            throw new NotFoundException("Actor not found.");

        if (!string.IsNullOrEmpty(actor.FullName))
            actorEntity.UpdateFullName(actor.FullName);
        
        actorEntity.UpdateAge(actor.Age);
        
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return actorEntity.ToDto();
    }
}