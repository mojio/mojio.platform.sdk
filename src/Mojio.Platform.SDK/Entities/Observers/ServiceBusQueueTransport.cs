using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{

    public class ServiceBusQueueTransport : BaseTransport, IServiceBusQueueTransport
    {
        public string ConnectionString { get; set; }

        public string Path { get; set; }

        public override TransportTypes TransportType => TransportTypes.ServiceBusQueue;
        public override string Type => TransportTypes.ServiceBusQueue.ToString().ToLower();
    }
}
