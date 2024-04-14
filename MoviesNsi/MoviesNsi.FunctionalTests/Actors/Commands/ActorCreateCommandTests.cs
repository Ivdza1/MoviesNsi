using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.OpenApi.Extensions;
using Moq;
using MoviesNsi.Application.Actors.Commands;
using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Application.Common.Interfaces;
using MoviesNsi.BaseTests.Builders.Commands;
using MoviesNsi.BaseTests.Builders.Domain;
using MoviesNsi.BaseTests.Builders.Dto;
using Xunit;

namespace MoviesNsi.FunctionalTests.Actors.Commands;

public class ActorCreateCommandTests : BaseTests
{
    /*public static readonly JsonSerializerOptions DefaultOptions = new();

    public static readonly JsonSerializerOptions SettingsWebOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };*/
    
    [Fact]
    public async Task ActorCreateCommandTest_GivenValidActorId_StatusOk()
    {
  
        // Given
        var movie = new MovieBuilder().Build();
        
        await MoviesNsiDbContext.Movies.AddAsync(movie);
        await MoviesNsiDbContext.SaveChangesAsync();

        var mock = new Mock<IMovieService>();

        mock.Setup(x => x.CreateAsync()).Returns("Test");

        var actorDto = new ActorCreateDtoBuilder().WithMovieId(movie.Id).Build();
        var actor = new ActorCreateCommandBuilder().WithActorCreateDto(actorDto).Build();

        var jsonActor = JsonSerializer.Serialize(actor);
        var contentRequest = new StringContent(jsonActor, Encoding.UTF8, "application/json");
        
        // When
        var response = await Client.PostAsync("/api/Actor/Create", contentRequest, new CancellationToken());
        
        // Then
        using var _ = new AssertionScope();
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ActorInfoDto>();
        content.Should()
            .NotBeNull();

    }

    public ActorCreateCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}