using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.Entities.Environments
{
    public partial class Environment : IEnvironment
    {
        public Contracts.Environments SelectedEnvironment { get; set; }
        public string AccountsUri { get; set; }
        public string APIUri { get; set; }
        public string ImagesUri { get; set; }
        public string PushUri { get; set; }
    }
}