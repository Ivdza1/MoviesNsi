using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Application.Exceptions;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Application.Movies.Commands;

public record MovieCreateCommand(MovieCreateDto Movie) : IRequest<MovieInfoDto?>;

public class MovieCreateCommandHandler(IMoviesNsiDbContext dbContext) : IRequestHandler<MovieCreateCommand, MovieInfoDto?>
{
    public async Task<MovieInfoDto?> Handle(MovieCreateCommand request, CancellationToken cancellationToken)
    {
        var movie = request.Movie.FromCreateDtoToEntity();

        dbContext.Movies.Add(movie);
        await dbContext.SaveChangesAsync(cancellationToken);

        return movie.ToDto();
    }
}
