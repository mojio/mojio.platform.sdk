using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class UsersTests
    {
        private readonly IClient _client;
        private IUser _me;

        public UsersTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
        }

        private async Task<IUser> GetMe()
        {
            if (_me != null)
                return _me;

            var response = await _client.Me();

            var me  = response.Response;
            _me = me;

            return _me;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetMeTestAsync()
        {
            var me = await _client.Me();
            Assert.NotNull(me.Response);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetUserTestAsync()
        {
            var me = await GetMe();
            var user = await _client.GetUser(me.Id);
            Assert.NotNull(user.Response);
        }

    }
}
