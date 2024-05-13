using Microsoft.AspNetCore.Mvc;
using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Application.Actors.Queries;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Domain.Common.Extensions;

namespace MoviesNsi.Controllers;
public class ActorController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Info([FromQuery] ActorInfoQuery query) => Ok(await Mediator.Send(query));

    [HttpPost]
    public async Task<IActionResult> Create(ActorCreateCommand command) => Ok(await Mediator.Send(command));

    [HttpPost("Test-Create")]
    public async Task<IActionResult> TestCreate(ActorTestCreateDto dto)
    {
        var command = dto.Json.Deserialize<ActorCreateCommand>(SerializerExtensions.SettingsWebOptions);
        return Ok(await Mediator.Send(command!));
    }

    [HttpPut]
    public async Task<IActionResult> Update(ActorUpdateCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}