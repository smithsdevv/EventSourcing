using MediatR;

namespace Application.Commands.User.UpdateUser;

public record UpdateUserCommand(Guid UserId, string FullName, string Email) : IRequest;