using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Movies.Queries;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Controllers;

public class MovieController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Info([FromQuery] MovieInfoQuery query) => Ok(await Mediator.Send(query));


    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var movie = new Movie(Guid.NewGuid(),"film", "film", 7);
        dbContext.Movies.Add(movie);
        await dbContext.SaveChangesAsync(new CancellationToken());
        
        return Ok();
    }
}