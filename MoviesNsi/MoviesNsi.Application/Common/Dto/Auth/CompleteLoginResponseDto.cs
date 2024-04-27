namespace MoviesNsi.Application.Common.Dto.Auth;

public record CompleteLoginResponseDto(string? EmailAdress = null, List<string>? Roles = null, string? JwtToken = null);