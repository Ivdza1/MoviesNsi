using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesNsi.Application.Users.Commands;

namespace MoviesNsi.Controllers;

public class UserController : ApiControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}