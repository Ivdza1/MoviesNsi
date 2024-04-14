using MediatR;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;

namespace MoviesNsi.Application.Actors.Commands;

public record ActorCreateCommand(ActorCreateDto Actor) : IRequest<ActorInfoDto?>;

public class ActorCreateCommandHandler(IActorService actorService) : IRequestHandler<ActorCreateCommand, ActorInfoDto?>
{
    public async Task<ActorInfoDto?> Handle(ActorCreateCommand request, CancellationToken cancellationToken) => await actorService.CreateAsync(request.Actor, cancellationToken);
}
