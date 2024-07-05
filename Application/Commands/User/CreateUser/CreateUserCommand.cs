using MediatR;

namespace Application.Commands.User.CreateUser;

public record CreateUserCommand(Guid UserId, string FullName, string Email) : IRequest;