using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{

    public class ServiceBusQueueTransport : BaseTransport, IServiceBusQueueTransport
    {
        public ServiceBusQueueTransport()
        {
            TransportType = TransportTypes.ServiceBusQueue;
        }
        public string ConnectionString { get; set; }

        public string Path { get; set; }


    }
}
