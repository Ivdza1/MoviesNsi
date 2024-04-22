using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Domain.Entities;
using MoviesNsi.Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class MovieMapper
{
    public static MovieInfoDto ToDto(this Movie entity)
    {
        var dto = 
            new MovieInfoDto
                (entity.Name, entity.Description, entity.Rating, new List<ActorInfoDto>(), entity.Category.Name, 
                    entity.Category.Subcategories.Select(x => x.Name).ToList());
        return dto;
    }

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