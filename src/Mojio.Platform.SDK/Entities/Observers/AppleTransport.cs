using System;
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class AppleTransport : BaseTransport, IAppleTransport
    {
        public string DeviceToken { get; set; }
        public string AlertBody { get; set; }
        public string AlertSound { get; set; }
        public string AlertCategory { get; set; }
        public int Badge { get; set; }
        public Guid AppId { get; set; }

        public override TransportTypes TransportType => TransportTypes.Apple;
        public override string Type => TransportTypes.Apple.ToString().ToLower();
    }
}
