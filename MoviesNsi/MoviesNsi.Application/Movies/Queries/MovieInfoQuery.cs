using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Application.Exceptions;

namespace MoviesNsi.Application.Movies.Queries;

public record MovieInfoQuery(string Id) : IRequest<MovieInfoDto?>;

public class MovieInfoQueryHandler(IMoviesNsiDbContext dbContext) : IRequestHandler<MovieInfoQuery, MovieInfoDto?>
{
    public async Task<MovieInfoDto?> Handle(MovieInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.Movies
            .Include(x => x.Actors)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken);

        if (result == null) throw new NotFoundException("Movie not found.", new { request.Id });
        
        var dto = result.ToDto();
        return dto;
    }
}