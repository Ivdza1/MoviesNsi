using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class ActorMapper
{
    public static partial ActorInfoDto ToDto(this Domain.Entities.Actor entity);
    public static partial Domain.Entities.Actor ToEntity(this Domain.Entities.Actor entity);

    public static Domain.Entities.Actor ToCustomDto(this ActorCreateDto dto, Movie movie)
    {
        var actor = new Domain.Entities.Actor(dto.FullName, dto.Age, movie);
        return actor;
    }
    
}