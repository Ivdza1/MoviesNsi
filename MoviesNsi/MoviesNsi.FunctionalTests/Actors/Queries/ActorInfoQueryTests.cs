using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Exceptions;
using MoviesNsi.Domain.Entities;
using MoviesNsi.Infrastructure.Contexts;
using Xunit;

namespace MoviesNsi.FunctionalTests.Actors.Queries;

public class ActorInfoQueryTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    
    public ActorInfoQueryTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }
    
    [Fact]
    public async Task ActorInfoQueryTest_GivenValidActorId_StatusOk()
    {
        
        using var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MoviesNsiDbContext>();
        
        // Given
        var movie = new Movie("-", "-", 1);
        var actor = new Actor("-", 0).AddMovie(movie);
        await dbContext.Actors.AddAsync(actor);
        await dbContext.SaveChangesAsync();

        // When
        var response = await _client.GetAsync($"/api/Actor/Info?Id={actor.Id.ToString()}");
        
        // Then
        using var _ = new AssertionScope();
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ActorInfoDto>();
        content.Should().NotBeNull();
        content!.fullName.Should().Be(actor.FullName);
        content!.MovieName.Should().Be(movie.Name);
        

    }
}