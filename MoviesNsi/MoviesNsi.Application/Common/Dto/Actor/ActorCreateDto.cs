namespace MoviesNsi.Application.Common.Dto.Actor;

public record ActorCreateDto(Guid MovieId, string FullName, int Age);