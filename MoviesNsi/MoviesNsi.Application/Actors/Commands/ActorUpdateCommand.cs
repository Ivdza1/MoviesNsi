using MediatR;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;

namespace MoviesNsi.Application.Actors.Commands;

public record ActorUpdateCommand(Guid actorId, ActorUpdateDto Actor) : IRequest<ActorInfoDto?>;

public class ActorUpdateCommandHandler(IActorService actorService) : IRequestHandler<ActorUpdateCommand, ActorInfoDto?>
{
    public async Task<ActorInfoDto?> Handle(ActorUpdateCommand request, CancellationToken cancellationToken) => await actorService.UpdateAsync(request.actorId, request.Actor, cancellationToken);
}
