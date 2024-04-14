using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.BaseTests.Builders.Dto;

namespace MoviesNsi.BaseTests.Builders.Commands;

public class ActorCreateCommandBuilder
{
    private ActorCreateDto _actorCreateDto = new ActorCreateDtoBuilder().Build();
    public ActorCreateCommand Build() => new(_actorCreateDto);

    public ActorCreateCommandBuilder WithActorCreateDto(ActorCreateDto actorCreateDto)
    {
        _actorCreateDto = actorCreateDto;
        return this;
    }
}