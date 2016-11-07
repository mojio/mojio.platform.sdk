using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class SignalRTransport : BaseTransport, ISignalRTransport
    {
        public string ClientId { get; set; }
        public string HubName { get; set; }
        public string Callback { get; set; }
        public override TransportTypes TransportType => TransportTypes.SignalR;
        public override string Type => TransportTypes.SignalR.ToString().ToLower();
    }
}
