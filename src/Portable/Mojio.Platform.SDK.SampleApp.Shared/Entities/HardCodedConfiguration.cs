using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.SampleApp.Shared.Entities
{
    public class HardCodedConfiguration : IConfiguration
    {
        public IEnvironment Environment { get; set; }
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string ClientSecret { get; set; }
    }
}