using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{

    public class EventHubTransport : BaseTransport, IEventHubTransport
    {
        public EventHubTransport()
        {
            TransportType = TransportTypes.EventHub;
        }
        public string ConnectionString { get; set; }

        public string Path { get; set; }


    }
}
