using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class MojioTests
    {
        private readonly IClient _client;
        private IMojio Mojio { get; set; }

        public MojioTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
        }

        private async Task<IMojio> GetMojioAsync()
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
        public async Task GetMojiosTestAsync()
        {
            var mojios = await _client.Mojios();
            Assert.NotNull(mojios.Response.Data);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task ClaimMojioTestAsync()
        {
            var imei = "999456890123000";
            var claimResponse = await _client.ClaimMojio(imei);

            Assert.NotNull(claimResponse.Response);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task RenameMojioTestAsync()
        {
            var mojio = await GetMojioAsync();

            var renameResponse = await _client.RenameMojio(mojio.Id, "newname");
            Assert.NotNull(renameResponse.Response);
        }

    }
}
