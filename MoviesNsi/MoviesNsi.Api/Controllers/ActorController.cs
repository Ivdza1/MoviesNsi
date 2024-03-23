using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Common.Mappers;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Controllers;

[ApiController]
[Route("Actor")]
public class ActorController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet("Info")]
    public async Task<IActionResult> Info(string id)
    {

       var result = await dbContext.Actors
            .Include(x => x.Movie)
            .Where(x => x.FullName == "Tom Kruz")
            .FirstOrDefaultAsync();
        
        if(result == null)
            return Ok();

        var dto = result.ToDto();
        return Ok(dto);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(ActorCreateDto actorDto)
    {
        var movie = await dbContext.Movies
            .Where(x => x.Id == actorDto.MovieId)
            .FirstOrDefaultAsync();

        if (movie == null) return Ok();

        var entity = actorDto.ToCustomDto(movie);

        dbContext.Actors.Add(entity);
        await dbContext.SaveChangesAsync(new CancellationToken());
        return Ok();
    }
}