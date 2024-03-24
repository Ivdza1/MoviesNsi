using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Application.Exceptions;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Application.Actors.Commands;

public record ActorCreateCommand(ActorCreateDto Actor) : IRequest<ActorInfoDto?>;

public class ActorCreateCommandHandler(IMoviesNsiDbContext dbContext) : IRequestHandler<ActorCreateCommand, ActorInfoDto?>
{
    public async Task<ActorInfoDto?> Handle(ActorCreateCommand request, CancellationToken cancellationToken)
    {

        var movie = await dbContext.Movies
            .Where(x => x.Id == request.Actor.MovieId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (movie == null)
            throw new NotFoundException("Movie not found.");

        var actor = request.Actor.FromCreateDtoToEntity().AddMovie(movie);

        dbContext.Actors.Add(actor);
        await dbContext.SaveChangesAsync(cancellationToken);

        return actor.ToDto();
    }
}
