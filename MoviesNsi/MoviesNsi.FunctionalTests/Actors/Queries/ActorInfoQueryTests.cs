using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Domain.Entities;
using MoviesNsi.Infrastructure.Contexts;
using Xunit;

namespace MoviesNsi.FunctionalTests.Actors.Queries;

public class ActorInfoQueryTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ActorInfoQueryTest_GivenValidActorId_StatusOk()
    {
        
        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MoviesNsiDbContext>();
        
        // Given
        var movie = new Movie("-", "-", 1);
        var actor = new Actor("-", 5).AddMovie(movie);
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
    
    [Fact]
    public async Task ActorInfoQueryTest_GivenActorIdAsNull_BadRequest()
    {
        // Given

        // When
        var response = await _client.GetAsync("/api/Actor/Info");
        
        // Then
        using var _ = new AssertionScope();
        
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
        
    }
    
    [Fact]
    public async Task ActorInfoQueryTest_GivenNotExistingActorId_NotFound()
    {
        
        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MoviesNsiDbContext>();
        
        // Given
        var movie = new Movie("-", "-", 1);
        var actor = new Actor("-", 5).AddMovie(movie);
        await dbContext.Actors.AddAsync(actor);
        await dbContext.SaveChangesAsync();

        // When
        var response = await _client.GetAsync($"/api/Actor/Info?Id={Guid.NewGuid()}");
        
        // Then
        using var _ = new AssertionScope();
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);

    }
}