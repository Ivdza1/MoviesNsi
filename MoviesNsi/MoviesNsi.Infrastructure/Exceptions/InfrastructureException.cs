using MoviesNsi.Application.Exceptions;

namespace MoviesNsi.Infrastructure.Exceptions;

public class InfrastructureException(string message, object? additionalData = null) : BaseException(message,
    additionalData);