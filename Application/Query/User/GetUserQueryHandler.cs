using Domain.Repositories;
using MediatR;

namespace Application.Query.User;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Domain.Entities.User>
{
  private readonly IEventStoreRepository<Domain.Entities.User> _repository;

  public GetUserQueryHandler(IEventStoreRepository<Domain.Entities.User> repository)
  {
    this._repository = repository;
  }

  public async Task<Domain.Entities.User> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    return await this._repository.LoadInlineProjectionAsync(request.UserId);
  }
}