using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesNsi.Application.Roles.Commands;

namespace MoviesNsi.Controllers;

public class RoleController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> CreateRole(CreateRoleCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}