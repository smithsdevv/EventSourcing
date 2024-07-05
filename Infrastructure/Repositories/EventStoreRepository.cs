using Domain.Entities;
using Domain.Events;
using Domain.Repositories;
using Marten;

namespace Infrastructure.Repositories;

public class EventStoreRepository<T> : IEventStoreRepository<T> where T : class
{
  private readonly IDocumentSession _session;
  private IQuerySession _querySession;
  
  public EventStoreRepository(IDocumentSession session, IQuerySession querySession)
  {
    _session = session;
    this._querySession = querySession;
  }
  
  public async Task AppendEventsAsync(IEvent @event)
  {
    _session.Events.Append(@event.StreamId, @event);
    await _session.SaveChangesAsync();
  }

  public Task<T?> LoadProjectionAsync(Guid streamId)
  {
    return this._querySession.Events.AggregateStreamAsync<T>(streamId);
  }
}