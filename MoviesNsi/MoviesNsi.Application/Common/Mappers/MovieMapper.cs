using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class MovieMapper
{
    public static partial MovieInfoDto ToDto(this Movie entity);
    public static partial Movie FromCreateDtoToEntity(this Movie entity);

    public static Movie ToCustomDto(this MovieCreateDto dto, Actor actor)
    {
        var movie = new Movie(Guid.NewGuid(), dto.Name, dto.Description, dto.Rating);
        return movie;
    }   
}