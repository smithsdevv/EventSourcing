using Domain.Events;

namespace Domain.Repositories;

public interface IEventStoreRepository<T>
{
  public  Task AppendEventsAsync(IEvent @event);

  public Task<T?> LoadProjectionAsync(Guid streamId);
}