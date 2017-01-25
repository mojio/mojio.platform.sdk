using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mojio.platform.sdk.test;
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
            loginResults = _loginSimpleClient.Login(Mother.Credentials.Item1, Mother.Credentials.Item3).Result;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public Task BasicLoginTest()
        {
            Assert.NotNull(loginResults?.Response?.MojioApiToken);
            return Task.CompletedTask;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicles()
        {
            var vehicles = await _loginSimpleClient.Vehicles();
            Assert.NotNull(vehicles?.Response?.Data);

        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetMojios()
        {
            var vehicles = await _loginSimpleClient.Mojios();
            Assert.NotNull(vehicles?.Response?.Data);

        }
        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetMe()
        {
            var vehicles = await _loginSimpleClient.Me();
            Assert.NotNull(vehicles?.Response?.Id);
            Assert.True(vehicles?.Response?.Id != Guid.NewGuid());         

        }
    }
}