using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Domain.Entities;
using MoviesNsi.Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class MovieMapper
{
    public static partial MovieInfoDto ToDto(this Movie entity);

    public static Movie FromCreateDtoToEntity(this MovieCreateDto dto)
    {
        var movie = new Movie(dto.Name, dto.Description, dto.Rating, Category.FromValue(dto.Category));
        return movie; 
    }

    public static Movie ToCustomDto(this MovieCreateDto dto, Actor actor, Category category)
    {
        var movie = new Movie(dto.Name, dto.Description, dto.Rating, category);
        return movie;
    }   
}