namespace MoviesNsi.Domain.Entities;

public class Actor
{
    private Actor() {}

    public Actor(string fullName, int age, Guid movieId)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Age = age;
        MovieId = movieId;
    }
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; } 
    public int Age { get; private set; }
    public Guid MovieId { get; private set; }
    public Movie Movie { get; private set; }
}