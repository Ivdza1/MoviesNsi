using MoviesNsi.Application.Common.Dto.Auth;

namespace MoviesNsi.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAdress);
    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}