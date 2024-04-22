using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.BaseTests.Builders.Domain;
using Xunit;

namespace MoviesNsi.FunctionalTests.Actors.Queries;

public class ActorInfoQueryTests : BaseTests
{

    [Fact]
    public async Task ActorInfoQueryTest_GivenValidActorId_StatusOk()
    {
        
        // Given
        var movie = new MovieBuilder().Build();
        var actor = new ActorBuilder().Build().AddMovie(movie);

        await MoviesNsiDbContext.Actors.AddAsync(actor);
        await MoviesNsiDbContext.SaveChangesAsync();
        
        // When
        var response = await Client.GetAsync($"/api/Actor/Info?Id={actor.Id.ToString()}");
        
        // Then
        using var _ = new AssertionScope();
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ActorInfoDto>();
        content.Should().NotBeNull();
        content!.FullName.Should().Be(actor.FullName);
        content!.MovieName.Should().Be(movie.Name);
        

    }
    
    [Fact]
    public async Task ActorInfoQueryTest_GivenActorIdAsNull_BadRequest()
    {
        // Given

        // When
        var response = await Client.GetAsync("/api/Actor/Info");
        
        // Then
        using var _ = new AssertionScope();
        
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
        
    }
    
    [Fact]
    public async Task ActorInfoQueryTest_GivenNotExistingActorId_NotFound()
    {
        
        // Given
        var movie = new MovieBuilder().Build();
        var actor = new ActorBuilder().Build().AddMovie(movie);
        await MoviesNsiDbContext.Actors.AddAsync(actor);
        await MoviesNsiDbContext.SaveChangesAsync();

        // When
        var response = await Client.GetAsync($"/api/Actor/Info?Id={Guid.NewGuid()}");
        
        // Then
        using var _ = new AssertionScope();
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);

    }

    public ActorInfoQueryTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}