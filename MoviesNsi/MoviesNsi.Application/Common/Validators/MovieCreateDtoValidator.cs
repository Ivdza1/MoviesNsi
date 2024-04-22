using FluentValidation;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Domain.Common.Extensions;
using MoviesNsi.Domain.Enums;

namespace MoviesNsi.Application.Common.Validators;

public class MovieCreateDtoValidator : AbstractValidator<MovieCreateDto>
{
    public MovieCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        
        RuleFor(x => x.Description)
            .MaximumLength(350);
        
        RuleFor(x => x.Category)
            .Must(t => Category.TryFromValue(t, out _))
            .WithMessage(_ => $"Category is not valid and must be in a list of: {EnumExtensions.CategoryValidList}");
    }
}