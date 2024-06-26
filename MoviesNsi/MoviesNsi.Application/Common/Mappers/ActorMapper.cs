using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class ActorMapper
{
    public static partial ActorInfoDto ToDto(this Actor entity);
    public static partial Actor FromCreateDtoToEntity(this ActorCreateDto dto);

    public static Actor ToCustomDto(this ActorCreateDto dto, Movie movie)
    {
        var actor = new Actor(dto.FullName, dto.Age);
        return actor;
    }
    
}