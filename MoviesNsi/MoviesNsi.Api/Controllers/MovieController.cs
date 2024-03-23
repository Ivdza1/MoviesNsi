using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Controllers;

[ApiController]
[Route("Movie")]
public class MovieController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet("Info")]
    public async Task<IActionResult> Info()
    {

        var result = await dbContext.Movies
            .Include(x => x.Actors)
            .ToListAsync();
        
        return Ok();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create()
    {
        var movie = new Movie("film", "film", 7);
        dbContext.Movies.Add(movie);
        await dbContext.SaveChangesAsync(new CancellationToken());
        
        return Ok();
    }
}