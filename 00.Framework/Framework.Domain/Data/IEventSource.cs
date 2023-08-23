using Framework.Domain.Events;

namespace CBSD.Framework.Domain.Data
{
    public interface IEventSource
    {
        void Save<TEvent>(string aggregateName, string streamId, IEnumerable<TEvent> events) where TEvent : IEvent;
    }
}
