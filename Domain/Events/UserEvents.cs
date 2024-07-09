namespace Domain.Events;

public class UserEvents
{
  public record UserCreatedEvent(Guid Id, string FullName, string Email) : IEvent;

  public record UserUpdatedEvent(Guid Id, string FullName, string Email) : IEvent;
  
  public record UserDeletedEvent(Guid Id) : IEvent;
}