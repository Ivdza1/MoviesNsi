using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> Create()
    {
        var movie = new Movie("film", "film", 7);
        var actor = new Actor("Glumac", 34, movie);
        dbContext.Actors.Add(actor);
        await dbContext.SaveChangesAsync(new CancellationToken());
        
        return Ok();
    }
}