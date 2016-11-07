using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public abstract class BaseTransport : ITransport
    {
        public string Key { get; set; }
        public abstract TransportTypes TransportType { get; }
        public abstract string Type { get; }

    }
}