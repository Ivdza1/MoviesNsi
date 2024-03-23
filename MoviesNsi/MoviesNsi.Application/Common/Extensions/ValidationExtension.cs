using FluentValidation.Results;

namespace MoviesNsi.Application.Extensions;

public static class ValidationExtensions
{
    public static IDictionary<string, string[]> ToGroup(this IEnumerable<ValidationFailure> validationFailures)
    {
        return validationFailures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}