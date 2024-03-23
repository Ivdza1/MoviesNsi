using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class MovieMapper
{
    public static partial MovieInfoDto ToDto(this Movie entity);
    public static partial Domain.Entities.Movie ToEntity(this Domain.Entities.Movie entity);

    public static Domain.Entities.Movie ToCustomDto(this MovieCreateDto dto, Actor actor)
    {
        var movie = new Domain.Entities.Movie(Guid.NewGuid(), dto.Name, dto.Description, dto.Rating);
        return movie;
    }   
}