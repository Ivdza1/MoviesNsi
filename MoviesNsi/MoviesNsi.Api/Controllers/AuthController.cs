using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesNsi.Application.Auth.Commands.BeginLoginCommand;
using MoviesNsi.Application.Auth.Commands.CompleteLoginCommand;

namespace MoviesNsi.Controllers;

public class AuthController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validatonToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validatonToken) =>
        Ok(await Mediator.Send(new CompleteLoginCommand(validatonToken)));
}