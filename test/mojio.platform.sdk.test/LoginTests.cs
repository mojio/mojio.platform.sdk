using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Xunit;

namespace Mojio.Platform.SDK.Tests
{
    public class LoginTests
    {
        public LoginTests()
        {
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "Load")]
        public async Task BasicLoginTest()
        {

            var client = Mother.SimpleClient;

            var result = await client.Login(Mother.Username, Mother.Password);
            Assert.NotNull(result?.Response?.MojioApiToken);

        }
    }
}
