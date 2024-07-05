namespace Domain.Events;

public interface  IEvent
{
  public  Guid StreamId { get; }
}