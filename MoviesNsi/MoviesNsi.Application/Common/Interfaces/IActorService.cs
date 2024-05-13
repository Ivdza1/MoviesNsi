using MoviesNsi.Application.Common.Dto.Actor;

namespace MoviesNsi.Application.Common.Interfaces;

public interface IActorService
{
    Task<ActorInfoDto> CreateAsync(ActorCreateDto actor, CancellationToken cancellationToken);
    Task<ActorInfoDto> UpdateAsync(Guid actorId, ActorUpdateDto actor, CancellationToken cancellationToken);
}