using MediatR;

namespace Application.Query.User;

public record GetUserQuery(Guid UserId) : IRequest<Domain.Entities.User>
{
}