using FluentValidation;
using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Dto.Movie;
using MoviesNsi.Domain.Common.Extensions;
using MoviesNsi.Domain.Enums;

namespace MoviesNsi.Application.Common.Validators;

public class ActorTestCreateDtoValidator : AbstractValidator<ActorTestCreateDto>
{
    public ActorTestCreateDtoValidator()
    {
        RuleFor(x => x.Json)
            .Must(t => t.TryDeserializeJson<ActorCreateCommand>(out _, SerializerExtensions.SettingsWebOptions))
            .WithMessage("Json is not in good format");
    }
}