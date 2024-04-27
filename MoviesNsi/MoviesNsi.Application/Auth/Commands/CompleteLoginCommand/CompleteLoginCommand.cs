using MediatR;
using MoviesNsi.Application.Common.Dto.Auth;
using MoviesNsi.Application.Common.Interfaces;

namespace MoviesNsi.Application.Auth.Commands.CompleteLoginCommand;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;

public class BeginLoginHandler(IAuthService authService) : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken) =>
        await authService.CompleteLoginAsync(request.ValidationToken);
}