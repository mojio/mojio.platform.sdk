using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class HttpPostTransport : BaseTransport, IHttpPostTransport
    {
        public string Address { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public override TransportTypes TransportType => TransportTypes.HttpPost;
        public override string Type => TransportTypes.HttpPost.ToString().ToLower();
    }
}
