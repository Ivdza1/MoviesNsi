using MoviesNsi.Application.Exceptions;

namespace MoviesNsi.Application.Actors.Exceptions;

public class ActorException : BaseException
{
    public ActorException(string message, object? additionalData = null) : base(message, additionalData)
    {
    }
}