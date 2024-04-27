using FluentValidation;

namespace MoviesNsi.Application.Auth.Commands.BeginLoginCommand;

public class BeginLoginModelValidator : AbstractValidator<BeginLoginCommand>
{
    public BeginLoginModelValidator()
    {
        RuleFor(x => x.EmailAdress)
            .EmailAddress()
            .NotEmpty();
    }
}