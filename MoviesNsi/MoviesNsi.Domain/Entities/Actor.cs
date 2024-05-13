using Ardalis.GuardClauses;

namespace MoviesNsi.Domain.Entities;

public class Actor
{
    private Actor() {}

    public Actor(string fullName, int age)
    {
        Id = Guid.NewGuid();
        FullName = Guard.Against.NullOrEmpty(fullName);
        Age = age;
    }

    public Actor AddMovie(Movie movie)
    {
        Movie = movie;
        //MovieId = movie.Id;
        return this;
    }

    public void UpdateFullName(string fullName)
    {
        FullName = fullName;
    }

    public void UpdateAge(int age)
    {
        Age = age;
    }
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; } 
    public int Age { get; private set; }
    public Guid MovieId { get; private set; }
    public Movie Movie { get; private set; }
}