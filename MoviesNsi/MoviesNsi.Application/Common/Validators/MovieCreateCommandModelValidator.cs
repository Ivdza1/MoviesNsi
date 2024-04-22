using FluentValidation;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Application.Movies.Commands;

namespace MoviesNsi.Application.Common.Validators;

public class MovieCreateCommandModelValidator : AbstractValidator<MovieCreateCommand>
{
    public MovieCreateCommandModelValidator()
    {
        RuleFor(x => x.Movie)
            .SetValidator(new MovieCreateDtoValidator());
    }
}