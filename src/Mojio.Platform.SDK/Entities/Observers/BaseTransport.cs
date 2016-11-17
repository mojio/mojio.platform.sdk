using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class BaseTransport : ITransport
    {
        public string Key { get; set; }
        public virtual TransportTypes TransportType { get; set; }
        public virtual string Type { get; set; }

    }
}