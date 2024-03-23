using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;

namespace MoviesNsi.Application.Actors.Queries;

public record ActorInfoQuery(string Id) : IRequest<ActorInfoDto?>;

public class ActorInfoQueryHandler(IMoviesNsiDbContext dbContext) : IRequestHandler<ActorInfoQuery, ActorInfoDto?>
{
    public async Task<ActorInfoDto?> Handle(ActorInfoQuery request, CancellationToken cancellationToken)
    {

        var result = await dbContext.Actors
            .Include(x => x.Movie)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var dto = result?.ToDto();
        return dto;
    }
}
