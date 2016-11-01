using Mojio.Platform.SDK.SampleApp.Shared.Contracts;

namespace Mojio.Platform.SDK.SampleApp.Shared.Entities
{
    public class Localization : ILocalization
    {
        public string GetTranslation(string key)
        {
            return key;
        }
    }
}