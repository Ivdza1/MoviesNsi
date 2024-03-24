using Microsoft.AspNetCore.Mvc;
using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Application.Actors.Queries;
using MoviesNsi.Application.Common.Interfaces;

namespace MoviesNsi.Controllers;
public class ActorController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Info([FromQuery] ActorInfoQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(ActorCreateCommand command) => Ok(await Mediator.Send(command));
}