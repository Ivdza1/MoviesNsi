using MoviesNsi.Application.Common.Dto.Actor;

namespace MoviesNsi.BaseTests.Builders.Dto;

public class ActorCreateDtoBuilder
{
    private Guid _movieId;
    private string _fullName = default!;
    private int _age;
    public ActorCreateDto Build() => new(_movieId, _fullName, _age);

    public ActorCreateDtoBuilder WithMovieId(Guid movieId)
    {
        _movieId = movieId;
        return this;
    }
    
    public ActorCreateDtoBuilder WithFullName(string fullName)
    {
        _fullName = fullName;
        return this;
    }
    
    public ActorCreateDtoBuilder WithAge(int age)
    {
        _age = age;
        return this;
    }
}