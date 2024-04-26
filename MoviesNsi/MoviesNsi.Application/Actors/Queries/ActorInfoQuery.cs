using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Application.Exceptions;
using MoviesNsi.Domain.Common.Extensions;

namespace MoviesNsi.Application.Actors.Queries;

public record ActorInfoQuery(string Id) : IRequest<ActorInfoDto>;

public class ActorInfoQueryHandler(IMoviesNsiDbContext dbContext) : IRequestHandler<ActorInfoQuery, ActorInfoDto>
{
    public async Task<ActorInfoDto> Handle(ActorInfoQuery request, CancellationToken cancellationToken)
    {

        var result = await dbContext.Actors
            .Include(x => x.Movie)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (result == null)
        {
            throw new NotFoundException("Actor not found.", new { request.Id });
        }
        
        
        var dto = result.ToDto();

        var testJson = dto.Serialize(SerializerExtensions.DefaultOptions);
        var testJson2 = dto.Serialize(SerializerExtensions.SettingsWebOptions);
        var testJson3 = dto.Serialize(SerializerExtensions.SettingsHardwareOptions);

        var deserializationDto = testJson.Deserialize<ActorInfoDto>(SerializerExtensions.DefaultOptions);
        var deserializationDto2 = testJson2.Deserialize<ActorInfoDto>(SerializerExtensions.SettingsWebOptions);
        var deserializationDto3 = testJson3.Deserialize<ActorInfoDto>(SerializerExtensions.SettingsHardwareOptions);

        var validateResult = await new ActorInfoQueryModelValidator().ValidateAsync(request, cancellationToken);
        
        return dto;
    }
}
