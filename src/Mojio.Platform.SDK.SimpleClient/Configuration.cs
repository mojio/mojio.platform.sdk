using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.SimpleClient
{
    public class Configuration : IConfiguration
    {
        public IEnvironment Environment { get; set; }
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string ClientSecret { get; set; }
    }
}