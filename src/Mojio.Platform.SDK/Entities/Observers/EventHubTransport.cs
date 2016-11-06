using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{

    public class EventHubTransport : BaseTransport, IEventHubTransport
    {
        public string ConnectionString { get; set; }

        public string Path { get; set; }

        public override TransportTypes TransportType => TransportTypes.EventHub;
        public override string Type => TransportTypes.EventHub.ToString().ToLower();
    }
}
