using MoviesNsi.Application.Common.Dto.Actor;

namespace MoviesNsi.Application.Common.Dto.Movie;

public record MovieInfoDto(string Name, string Description, int Rating, List<ActorInfoDto> Actors, string CategoryName, List<string> Subcategories);