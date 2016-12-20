using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        private IAuthorization _authorization;

        public async Task<IPlatformResponse<IAuthorization>> Login(string username, string password, string scope = "full", CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var auth = _container.Resolve<IAuthorization>();
            auth.UserName = username;
            auth.Password = password;
            auth.Scope = scope ?? "full";

            return await LoginInternal(auth, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IAuthorization>> Login(IAuthorization authorization, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            if (Authorization?.Signature == authorization?.Signature && authorization?.HasExpired == false)
            {
                var response = _container.Resolve<IPlatformResponse<IAuthorization>>();
                response.Success = true;
                response.CacheHit = true;
                response.Response = authorization;
                return response;
            }

            return await LoginInternal(authorization, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> Register(string email, string password, string username = null, string mobileNumber = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            //var segment = $"account/register?returnUrl=%2Foauth2%2Fauthorize&response_type=token&client_id={WebUtility.UrlEncode(Configuration.ClientId)}&redirect_uri={Configuration.RedirectUri}";
            var segment = $"account/register";

            var requestPayload = _serializer.SerializeToString(new
            {
                PhoneNumber = mobileNumber,
                Email = email,
                Password = password,
                Username = username,
                ConfirmPassword = password
            });

            //var requestPayload = $"MobileNumber={WebUtility.UrlEncode(mobileNumber)}&UserName={WebUtility.UrlEncode(username)}&Email={WebUtility.UrlEncode(email)}&Password={WebUtility.UrlEncode(password)}&ConfirmPassword={WebUtility.UrlEncode(password)}";

            var authHeader = new Dictionary<string, string>();

            var authFormatted = Convert.ToBase64String(Encoding.GetEncoding("ASCII").GetBytes($"{Configuration.ClientId}:{Configuration.ClientSecret}"));
            authHeader.Add("Authorization", $"Basic {authFormatted}");

            var result = await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Accounts, segment, tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, requestPayload, null, "application/json", authHeader);

            return result;
        }

        public IAuthorization Authorization
        {
            get { return _authorization; }
            set
            {
                _authorization = value;
                _clientBuilder.Authorization = value;
            }
        }

        public async Task<IPlatformResponse<IAuthorization>> RefreshToken(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            //lets try to refresh the token
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            var refreshPayload = string.Format("grant_type=refresh_token&refresh_token={0}&redirect_uri={1}&client_id={2}&client_secret={3}", System.Net.WebUtility.UrlEncode(Authorization.RefreshToken), System.Net.WebUtility.UrlEncode(Configuration.RedirectUri), System.Net.WebUtility.UrlEncode(Configuration.ClientId), System.Net.WebUtility.UrlEncode(Configuration.ClientSecret));
            var refreshResult = await _clientBuilder.Request<IAuthorization>(ApiEndpoint.Accounts, "oauth2/token", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, refreshPayload, null, "application/x-www-form-urlencoded");
            if (refreshResult.Success)
            {
                Authorization.AccessToken = refreshResult.Response.AccessToken;
                Authorization.ExpiresIn = refreshResult.Response.ExpiresIn;
                Authorization.RefreshToken = refreshResult.Response.RefreshToken;
                Authorization.TokenType = refreshResult.Response.TokenType;
                refreshResult.Response = Authorization;
                refreshResult.Response.IsLoggedIn = true;
                Authorization.Refreshed = true;
                refreshResult.Response.Success = true;

                _log.Debug("Valid expired token found, try to refresh our token - success");
                return refreshResult;
            }
            return null;
        }

        private async Task<IPlatformResponse<IAuthorization>> LoginInternal(IAuthorization authorization, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            Authorization = authorization;

            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if (!string.IsNullOrEmpty(authorization.AccessToken) && !authorization.HasExpired)
            {
                _log.Debug("Valid non-expired token found, login success");
                var result = _container.Resolve<IPlatformResponse<IAuthorization>>();
                result.Success = true;
                result.Response = authorization;
                result.Response.Refreshed = false;
                result.Response.Success = true;
                return result;
            }
            if (!string.IsNullOrEmpty(authorization.RefreshToken) && authorization.HasExpired)
            {
                //lets try to refresh the token
                _log.Debug("Valid expired token found, try to refresh our token");
                var refreshPayload = string.Format("grant_type=refresh_token&refresh_token={0}&redirect_uri={1}&client_id={2}&client_secret={3}", System.Net.WebUtility.UrlEncode(authorization.RefreshToken), System.Net.WebUtility.UrlEncode(Configuration.RedirectUri), System.Net.WebUtility.UrlEncode(Configuration.ClientId), System.Net.WebUtility.UrlEncode(Configuration.ClientSecret));
                var refreshResult = await _clientBuilder.Request<IAuthorization>(ApiEndpoint.Accounts, "oauth2/token", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, refreshPayload, null, "application/x-www-form-urlencoded");
                if (refreshResult.Success)
                {
                    authorization.AccessToken = refreshResult.Response.AccessToken;
                    authorization.ExpiresIn = refreshResult.Response.ExpiresIn;
                    authorization.RefreshToken = refreshResult.Response.RefreshToken;
                    authorization.TokenType = refreshResult.Response.TokenType;
                    refreshResult.Response = authorization;
                    refreshResult.Response.IsLoggedIn = true;
                    authorization.Refreshed = true;
                    _log.Debug("Valid expired token found, try to refresh our token - success");
                    refreshResult.Response.Success = true;

                    return refreshResult;
                }
            }

            _log.Info("No valid login access token found, calling login via username and password");

            var payload = string.Format("grant_type=password&username={0}&password={1}&redirect_uri={2}&client_id={3}&client_secret={4}&scope={5}", System.Net.WebUtility.UrlEncode(authorization.UserName), System.Net.WebUtility.UrlEncode(authorization.Password), System.Net.WebUtility.UrlEncode(Configuration.RedirectUri), System.Net.WebUtility.UrlEncode(Configuration.ClientId), System.Net.WebUtility.UrlEncode(Configuration.ClientSecret), System.Net.WebUtility.UrlEncode(authorization.Scope));

            var loginResult = await _clientBuilder.Request<IAuthorization>(ApiEndpoint.Accounts, "oauth2/token", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, payload, null, "application/x-www-form-urlencoded");

            if (loginResult.Success)
            {
                authorization.AccessToken = loginResult.Response.AccessToken;
                authorization.ExpiresIn = loginResult.Response.ExpiresIn;
                authorization.RefreshToken = loginResult.Response.RefreshToken;
                authorization.TokenType = loginResult.Response.TokenType;
                loginResult.Response = authorization;
                loginResult.Response.IsLoggedIn = true;
                loginResult.Response.Refreshed = true;
                loginResult.Response.Success = true;
                _log.Debug("Login via username and password - success");
            }
            return loginResult;
        }
    }
}