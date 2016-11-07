using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class AndroidTransport : BaseTransport, IAndroidTransport
    {
        public string DeviceRegistrationId { get; set; }

        public override TransportTypes TransportType => TransportTypes.Android;
        public override string Type => TransportTypes.Android.ToString().ToLower();
    }
}