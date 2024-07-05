using Domain.Events;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
  private readonly IEventStoreRepository<Domain.Entities.User> _repository;

  public UpdateUserCommandHandler(IEventStoreRepository<Domain.Entities.User> repository)
  {
    this._repository = repository;
  }

  public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    await this._repository.AppendEventsAsync(new UserEvents.UserUpdatedEvent()
    {
      UserId = request.UserId,
      FullName = request.FullName,
      Email = request.Email
    });
  }
}