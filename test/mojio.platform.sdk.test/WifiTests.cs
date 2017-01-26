using System;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class WifiTests
    {
        private readonly IClient _client;
        private IMojio Mojio { get; set; }

        public WifiTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
        }

        private async Task<IMojio> GetMojio()
        {
            if (Mojio != null)
                return Mojio;

            var mojios = await _client.Mojios();
            var mojio = mojios.Response.Data.First();

            Mojio = mojio;
            return mojio;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task UpdateWifiSettingsTestAsync()
        {
            var mojio = await GetMojio();

            var wifiUpdateResponse = await _client.UpdateWifiSettings(mojio.Id);
            Assert.NotNull(wifiUpdateResponse.Response);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetWifiSettingsAfterUpdateTestAsync()
        {
            var mojio = await GetMojio();

            var wifiUpdateResponse = await _client.GetWifiSettingsAfterUpdate(mojio.Id, String.Empty);
            Assert.NotNull(wifiUpdateResponse.Response);
        }
    }
}
