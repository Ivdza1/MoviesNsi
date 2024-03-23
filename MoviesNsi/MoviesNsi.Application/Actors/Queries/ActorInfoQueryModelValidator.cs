using FluentValidation;
using MoviesNsi.Application.Actor.Queries;

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