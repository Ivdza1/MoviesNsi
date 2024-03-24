using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.Application.Movies.Queries;
using MoviesNsi.Auth.Constants;
using MoviesNsi.Domain.Entities;

namespace MoviesNsi.Controllers;

public class MovieController(IMoviesNsiDbContext dbContext) : ApiControllerBase
{

    [HttpGet]
    [Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
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