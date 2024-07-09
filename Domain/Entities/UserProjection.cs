using Domain.Events;
using Marten.Events.Aggregation;


namespace Domain.Entities;

public class UserProjection : SingleStreamProjection<User>
{
  public static User Create(UserEvents.UserCreatedEvent e) => new(e.Id, e.Email, e.FullName);

  public User Apply(UserEvents.UserUpdatedEvent e, User current) =>
    current with { FullName = e.FullName, Email = e.Email };
}

