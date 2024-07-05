using Domain.Events;
using Marten.Schema;

namespace Domain.Entities;

public class User
{
  [Identity]
  public Guid UserId { get; set; }
  
  public string FullName { get; set; }
  
  public string Email { get; set; }

  private void Apply(UserEvents.UserCreatedEvent @event)
  {
    UserId = @event.UserId;
    FullName = @event.FullName;
    Email = @event.Email;
  }
  
  private void Apply(UserEvents.UserUpdatedEvent @event)
  {
    UserId = @event.UserId;
    FullName = @event.FullName;
    Email = @event.Email;
  }
  
  private void Apply(UserEvents.UserDeletedEvent @event)
  {
    UserId = @event.UserId;
  }
  
  public void Apply(IEvent @event)
  {
    switch (@event)
    {
      case UserEvents.UserCreatedEvent userCreated:
        Apply(userCreated);
        break;
      case UserEvents.UserUpdatedEvent userUpdated:
        Apply(userUpdated);
        break;
      case UserEvents.UserDeletedEvent userDeleted:
        Apply(userDeleted);
        break;
    }
  }
}