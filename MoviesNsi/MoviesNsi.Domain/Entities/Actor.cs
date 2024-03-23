namespace MoviesNsi.Domain.Entities;

public class Actor
{
    private Actor() {}

    public Actor(string fullName, int age)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Age = age;
    }
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public int Age { get; private set; }
    
    public IList<Movie> Movie { get; } = new List<Movie>();
}