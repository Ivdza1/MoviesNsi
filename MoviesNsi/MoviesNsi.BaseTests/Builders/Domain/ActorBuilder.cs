using MoviesNsi.Domain.Entities;

namespace MoviesNsi.BaseTests.Builders.Domain;

public class ActorBuilder
{
    private string _fullName = "-";
    private int _age = 1;

    
    public ActorBuilder WithFullName(string fullName)
    {
        _fullName = fullName;
        return this;
    }
    
    public ActorBuilder WithAge(int age)
    {
        _age = age;
        return this;
    }
    
    public Actor Build() => new(_fullName, _age);

}