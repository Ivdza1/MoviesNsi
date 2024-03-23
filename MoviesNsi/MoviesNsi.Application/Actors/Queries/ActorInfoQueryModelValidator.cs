using FluentValidation;

namespace MoviesNsi.Application.Actors.Queries;

public class ActorInfoQueryModelValidator : AbstractValidator<ActorInfoQuery>
{
    public ActorInfoQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty.")
            .MinimumLength(3);

    }
}