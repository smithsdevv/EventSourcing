using MediatR;

namespace Application.Commands.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
  public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}