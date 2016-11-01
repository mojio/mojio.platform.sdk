using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class BaseTransport : ITransport
    {
        public string Key { get; set; }
        public TransportTypes TransportType { get; set; } = TransportTypes.HttpPost;


    }
}