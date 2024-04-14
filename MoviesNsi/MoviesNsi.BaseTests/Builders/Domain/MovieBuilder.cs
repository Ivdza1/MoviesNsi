using MoviesNsi.Domain.Entities;

namespace MoviesNsi.BaseTests.Builders.Domain;

public class MovieBuilder
{
    private string _name = "-";
    private string _description = "-";
    private int _rating = 1;
    public Movie Build() => new(_name, _description, _rating);

    public MovieBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public MovieBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public MovieBuilder WithRating(int rating)
    {
        _rating = rating;
        return this;
    }
}