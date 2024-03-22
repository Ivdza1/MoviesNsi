namespace MoviesNsi.Domain.Entities;

public class Movie
{
    private Movie() {}

    public Movie(string name, string description, int rating)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Rating = rating;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Rating { get; private set; }
}