using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;

namespace MoviesNsi.Application.Movies.Queries;

public record MovieInfoQuery(string Id) : IRequest<MovieInfoDto?>;

public class MovieInfoQueryHandler(IMoviesNsiDbContext dbContext) : IRequestHandler<MovieInfoQuery, MovieInfoDto?>
{
    public async Task<MovieInfoDto?> Handle(MovieInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Movies
            .Include(x => x.Actors)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var dto = result?.ToDto();
        return dto;
    }
}