using MediatR;
using MoviesNsi.Application.Common.Dto.Auth;
using MoviesNsi.Application.Common.Interfaces;

namespace MoviesNsi.Application.Auth.Commands.BeginLoginCommand;

public record BeginLoginCommand(string EmailAdress) : IRequest<BeginLoginResponseDto>;

public class BeginLoginHandler(IAuthService authService) : IRequestHandler<BeginLoginCommand, BeginLoginResponseDto>
{
    public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken) =>
        await authService.BeginLoginAsync(request.EmailAdress);
}