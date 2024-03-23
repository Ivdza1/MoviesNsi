namespace MoviesNsi.Application.Exceptions;

public class BaseException : Exception
{
    public object? AdditionalData { get; }
    
    public BaseException(string message, object? additionalData = null) : base(message)
    {
        AdditionalData = additionalData;
    }
}