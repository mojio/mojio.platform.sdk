using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Automation;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Automation;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Tests;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class AutomationProfileTests
    {
        readonly IClient _loginSimpleClient = Mother.GetNewSimpleClient;
        private IPlatformResponse<IAuthorization> loginResults = null;
        public AutomationProfileTests()
        {
            loginResults = _loginSimpleClient.Login(Mother.Username, Mother.Password).Result;

            (new AutomationRegistrationContainer()).Register(Mother.DIContainer);

        }

        [Theory]
        [Trait("Category", "Automation")]
        [Trait("Category", "Integration")]
        [InlineData("ios")]
        [InlineData("android")]
        public async Task AutomationProfiles(string profileName)
        {
            var profile = Mother.DIContainer.Resolve<IAutomationProfile>(profileName);
            Assert.NotNull(profile);
            var logger = new ConsoleLogger(Mother.DIContainer.Resolve<ISerializer>());
            await profile.Execute(logger, _loginSimpleClient, new Dictionary<string, string>() {{"username", Mother.Username}, {"password", Mother.Password} });
        }

    }
}
