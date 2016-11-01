using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class HttpPostTransport : BaseTransport, IHttpPostTransport
    {
        public HttpPostTransport() : base()
        {
            TransportType = TransportTypes.HttpPost;
        }
        public string Address { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
