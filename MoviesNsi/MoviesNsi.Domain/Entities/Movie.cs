namespace MoviesNsi.Domain.Entities;

public class Movie
{
    private Movie() {}

    public Movie(Guid id, string name, string description, int rating)
    {
        Id = id;
        Name = name;
        Description = description;
        Rating = rating;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Rating { get; private set; }
    
    public IList<Actor> Actors { get; } = new List<Actor>();
}