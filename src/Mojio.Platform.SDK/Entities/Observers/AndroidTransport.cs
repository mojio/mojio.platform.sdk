using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class AndroidTransport : BaseTransport, IAndroidTransport
    {
        public AndroidTransport() : base()
        {
            TransportType = TransportTypes.Android;
        }

        public string DeviceRegistrationId { get; set; }


    }
}