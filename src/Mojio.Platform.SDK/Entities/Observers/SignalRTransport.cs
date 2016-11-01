using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class SignalRTransport : BaseTransport, ISignalRTransport
    {
        public SignalRTransport() : base()
        {
            TransportType = TransportTypes.SignalR;
        }
        public string ClientId { get; set; }
        public string HubName { get; set; }
        public string Callback { get; set; }

    }
}
