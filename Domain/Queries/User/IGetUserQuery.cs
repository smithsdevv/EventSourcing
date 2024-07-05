using MediatR;

namespace Domain.Queries.User;

public interface IGetUserQuery : IRequestHandler<GetUserQueryRequest, object>
{
  
}