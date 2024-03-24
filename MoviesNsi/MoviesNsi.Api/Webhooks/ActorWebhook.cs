using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Auth.Constants;

namespace MoviesNsi.Webhooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class ActorWebhook : BaseWebhook
{
    [HttpPost]
    public async Task<IActionResult> Create(ActorCreateCommand command) => Ok(await Mediator.Send(command));
}