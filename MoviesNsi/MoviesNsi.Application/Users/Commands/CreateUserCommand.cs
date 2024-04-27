using MediatR;
using MoviesNsi.Application.Common.Interfaces;

namespace MoviesNsi.Application.Users.Commands;

public record CreateUserCommand(string EmailAdress, List<string> Roles) : IRequest
{
    public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand>
    {
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken) => 
            await userService.CreateUserAsync(request.EmailAdress, request.Roles);
        
    }
}