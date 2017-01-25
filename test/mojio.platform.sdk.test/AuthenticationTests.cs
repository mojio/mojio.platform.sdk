using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.SimpleClient;
using Mojio.Platform.SDK.Tests;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class AuthenticationTests
    {
        private readonly IClient _client;
        
        public AuthenticationTests()
        {
            _client = new SimpleClient(Mother.Environment, new Configuration
            {
                ClientId = Mother.ClientId,
                ClientSecret = Mother.ClientSecret,
                RedirectUri = Mother.RedirectUri
            });
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginUsernameSpecialCasePasswordTestAsync()
        {
            var credentials = Mother.CredentialsWithSpecialCasePassword;
            var response = await _client.Login(credentials.Item1, credentials.Item3);

            Assert.NotNull(response.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginUsernameWithIncorrectPasswordTestAsync()
        {
            var credentials = Mother.Credentials;
            var response = await _client.Login(credentials.Item1, "ad*afxf.a(;");
            Assert.Null(response.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginUsernameWithEmptyPasswordTestAsync()
        {
            var credentials = Mother.Credentials;
            var response = await _client.Login(credentials.Item1, "");
            Assert.Null(response.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginEmailTestAsync()
        {
            var credentials = Mother.Credentials;
            var response = await _client.Login(credentials.Item2, credentials.Item3);
            Assert.NotNull(response.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginEmailWithSpecialCasePasswordTestAsync()
        {
            var credentials = Mother.CredentialsWithSpecialCasePassword;
            var response = await _client.Login(credentials.Item2, credentials.Item3);
            Assert.NotNull(response.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginWithAuthTokenTestAsync()
        {
            var credentials = Mother.Credentials;
            var response = await _client.Login(credentials.Item1, credentials.Item3);

            var responseWithToken = await _client.Login(response.Response?.MojioApiToken);
            Assert.NotNull(responseWithToken.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task LoginWithAuthorizationTestAsync()
        {
            var client = new SimpleClient(Mother.Environment, new Configuration
            {
                ClientId = Mother.ClientId,
                ClientSecret = Mother.ClientSecret,
                RedirectUri = Mother.RedirectUri
            });

            var credentials = Mother.Credentials;

            var authorization = new CoreAuthorization
            {
                UserName = credentials.Item1,
                Password = credentials.Item3
            };

            var response = await client.Login(authorization);
            Assert.NotNull(response.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task RefreshTokenTestAsync()
        {
            var credentials = Mother.Credentials;
            var response = await _client.Login(credentials.Item1, credentials.Item3);
            var refreshTokenResponse = await _client.RefreshToken();
            Assert.NotNull(refreshTokenResponse.Response?.MojioApiToken);
        }
    }
}
