namespace Domain.Events;

public class UserEvents
{
  public class UserCreatedEvent : IEvent
  {
    public Guid UserId { get; init; }

    public string FullName { get; init; }

    public string Email { get; init; }

    public Guid StreamId => UserId;
  }

  public class UserUpdatedEvent : IEvent
  {
    public Guid UserId { get; init; }

    public string FullName { get; init; }

    public string Email { get; init; }

    public Guid StreamId => UserId;
  }
  
  public class UserDeletedEvent : IEvent
  {
    public Guid UserId { get; init; }

    public Guid StreamId => UserId;
  }
}