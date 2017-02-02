using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Entities;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class AppTests
    {
        private readonly IClient _client;

        private IApp App { get; set; }

        public AppTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
        }

        private async Task<IApp> GetAppAsync()
        {
            if (App != null)
                return App;

            var apps = await _client.Apps();
            var app = apps.Response.Data.First();

            App = app;
            return app;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetAppsTestAsync()
        {
            var appsResponse = await _client.Apps();
            Assert.NotNull(appsResponse.Response);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task CreateAppTestAsync()
        {
            var testApp = new App
            {
                Name = "TestApp",
                Description = "Test App Description",
                RedirectUris = new List<string> { "http://www.moj.io" }
            };

            var testAppResponse = await _client.CreateApp(testApp);
            Assert.NotNull(testAppResponse);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task UpdateAppTestAsync()
        {
            var app = await GetAppAsync();
            app.Name = "Updated Name";

            var updateAppResponse = await _client.UpdateApp(app);
            Assert.True(updateAppResponse.Success);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetAppSecretTestAsync()
        {
            var app = await GetAppAsync();

            var appSecret = await _client.GetAppSecret(app.Id);
            Assert.NotNull(appSecret.Response);
        }

    }
}
