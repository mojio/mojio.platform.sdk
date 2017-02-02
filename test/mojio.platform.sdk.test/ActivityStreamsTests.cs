using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class ActivityStreamsTests
    {
        private readonly IClient _client;

        public ActivityStreamsTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetActivityStreamsAsyncTest()
        {
            var activities = await _client.UserActivityStream();
            Assert.NotNull(activities.Response.Data);
        }
    }
}
