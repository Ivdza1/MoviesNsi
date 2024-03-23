using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> Create(ActorCreateDto actorDto)
    {
        var movie = await dbContext.Movies
            .Where(x => x.Id.Equals(actorDto.MovieId))
            .FirstOrDefaultAsync();

        if (movie == null) return Ok();

        var entity = actorDto.ToCustomDto(movie);

        dbContext.Actors.Add(entity);
        await dbContext.SaveChangesAsync(new CancellationToken());
        return Ok();
    }
}