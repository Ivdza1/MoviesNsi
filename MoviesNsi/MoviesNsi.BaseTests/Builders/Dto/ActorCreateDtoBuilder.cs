using MoviesNsi.Application.Common.Dto.Actor;

namespace MoviesNsi.BaseTests.Builders.Dto;

public class ActorCreateDtoBuilder
{
    private Guid _movieId;
    private string _fullName = "-";
    private int _age = 1;

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
    public ActorCreateDto Build() => new(_movieId, _fullName, _age);
}