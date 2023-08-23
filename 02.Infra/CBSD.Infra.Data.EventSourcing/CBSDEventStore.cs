using System.Text;
using CBSD.Framework.Domain.Data;
using EventStore.ClientAPI;
using Framework.Domain.Events;
using Newtonsoft.Json;

namespace CBSD.Infra.Data.EventSourcing
{                          
    //"ConnectionString": "ConnectTo=tcp://admin:changeit@localhost:1113; DefaultUserCredentials=admin:changeit;"  
    public class CBSDEventStore : IEventSource
    {
        private readonly IEventStoreConnection _connection;
            public CBSDEventStore(IEventStoreConnection connection)
            {
                _connection = connection;
                _connection.ConnectAsync().Wait();
            }
            public void Save<TEvent>(string aggregateName, string streamId, IEnumerable<TEvent> events)
                where TEvent : IEvent
            {
                if (!events.Any()) return;
                var changes = events
                    .Select(@event =>
                        new EventData(
                            eventId: Guid.NewGuid(),
                            type: @event.GetType().Name,
                            isJson: true,
                            data: Serialize(@event),
                            metadata: Serialize(new EventMetadata
                                { ClrType = @event.GetType().AssemblyQualifiedName })
                        ))
                    .ToArray();
                if (!changes.Any()) return;
                var streamName = $"{aggregateName} - {streamId}";
                _connection.AppendToStreamAsync(
                    streamName,
                    ExpectedVersion.Any,
                    changes).Wait();
            }

            //helper for serializing classes to JSON for saving in eventStoreDB in byte[]
            private static byte[] Serialize(object data) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }
    //you can opt every field here
        internal class EventMetadata
        {
            public string ClrType { get; set; }
        }
    }
 