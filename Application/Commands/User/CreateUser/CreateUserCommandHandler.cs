using Domain.Events;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
  private readonly IEventStoreRepository<Domain.Entities.User> _repository;

  public CreateUserCommandHandler(IEventStoreRepository<Domain.Entities.User> repository)
  {
    this._repository = repository;
  }

  public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
  {
    await this._repository.AppendEventsAsync(new UserEvents.UserCreatedEvent()
    {
      UserId = request.UserId,
      FullName = request.FullName,
      Email = request.Email
    });
  }
}