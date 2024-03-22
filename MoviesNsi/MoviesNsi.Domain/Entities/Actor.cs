namespace MoviesNsi.Domain.Entities;

public class Actor
{
    private Actor() {}

    public Actor(string fullName, int age, Movie movie)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Age = age;
        Movie = movie;
    }
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public int Age { get; private set; }
    public Movie Movie { get; private set; }
}