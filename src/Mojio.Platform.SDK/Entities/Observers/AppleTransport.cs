using System;
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class AppleTransport : BaseTransport, IAppleTransport
    {
        public AppleTransport() : base()
        {
            TransportType = TransportTypes.Apple;
        }
        public string DeviceToken { get; set; }
        public string AlertBody { get; set; }
        public string AlertSound { get; set; }
        public string AlertCategory { get; set; }
        public int Badge { get; set; }
        public Guid AppId { get; set; }

    }
}
