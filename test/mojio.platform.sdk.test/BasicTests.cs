using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Xunit;

namespace Mojio.Platform.SDK.Tests
{
    public class BasicTests
    {
        readonly IClient _loginSimpleClient = Mother.GetNewSimpleClient;

        private IPlatformResponse<IAuthorization> loginResults = null;
        public BasicTests()
        {
            loginResults = _loginSimpleClient.Login(Mother.Username, Mother.Password).Result;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "Load")]
        public async Task BasicLoginTest()
        {
            Assert.NotNull(loginResults?.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "Load")]
        public async Task GetVehicles()
        {
            var vehicles = await _loginSimpleClient.Vehicles();
            Assert.NotNull(vehicles?.Response?.Data);

        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "Load")]
        public async Task GetMojios()
        {
            var vehicles = await _loginSimpleClient.Mojios();
            Assert.NotNull(vehicles?.Response?.Data);

        }
    }
}