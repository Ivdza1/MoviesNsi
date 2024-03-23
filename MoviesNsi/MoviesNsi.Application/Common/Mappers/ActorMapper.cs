using MoviesNsi.Application.Common.Dto.Actor;
using MoviesNsi.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MoviesNsi.Application.Common.Mappers;

[Mapper]
public static partial class ActorMapper
{
    public static partial ActorInfoDto ToDto(this Actor entity);
}