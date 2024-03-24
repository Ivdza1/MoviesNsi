using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Application.Actors.Queries;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Controllers;
public class ActorController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Info([FromQuery] ActorInfoQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(ActorCreateCommand command) => Ok(await Mediator.Send(command));
}