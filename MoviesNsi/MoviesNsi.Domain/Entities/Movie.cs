using MoviesNsi.Domain.Enums;

namespace MoviesNsi.Domain.Entities;

public class Movie
{
    private Movie() {}

    public Movie(Guid id, string name, string description, int rating)
    {
        
        // promenjeno iz id = id u new guid
        Id = id != Guid.Empty ? id : Guid.NewGuid();
        Name = name;
        Description = description;
        Rating = rating;
    }

    public Movie(string name, string description, int rating) : this(Guid.NewGuid(), name, description, rating)
    {
       
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Rating { get; private set; }
    
    //public Actor Actor { get; private set; }
    
    //public Guid ActorId { get; private set; }
    
    public IList<Actor> Actors { get; private set; } = new List<Actor>();
}