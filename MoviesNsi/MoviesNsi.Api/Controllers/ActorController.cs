using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Controllers;

[ApiController]
[Route("Actor")]
public class ActorController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet("Info")]
    public async Task<IActionResult> Info()
    {

       var result = await dbContext.Actors
            .Where(x => x.FullName == "Tom Kruz")
            .ToListAsync();
        
        return Ok();
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