using MoviesNsi.Application.Exceptions;

namespace MoviesNsi.Application.Movies.Exceptions;

public class MovieException : BaseException
{
    public MovieException(string message, object? additionalData = null) : base(message, additionalData)
    {
    }
}