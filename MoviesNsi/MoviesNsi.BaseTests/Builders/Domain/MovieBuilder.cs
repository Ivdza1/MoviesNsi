using MoviesNsi.Domain.Entities;
using MoviesNsi.Domain.Enums;

namespace MoviesNsi.BaseTests.Builders.Domain;

public class MovieBuilder
{
    private string _name = "-";
    private string _description = "-";
    private int _rating = 1;
    private Category _category = Category.Thriller;

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
    
    public MovieBuilder WithCategory(Category category)
    {
        _category = category;
        return this;
    }
    
    public Movie Build() => new(_name, _description, _rating, _category);
}