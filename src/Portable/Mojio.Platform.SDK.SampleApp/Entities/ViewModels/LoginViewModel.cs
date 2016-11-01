using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace Mojio.Platform.SDK.SampleApp.Entities.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private readonly IAuthorizationManager _authManager;
        private readonly INavigationService _navigationService;
        private bool _invalidUsernamePasswordVisibility;
        private string _loginUrl;

        public LoginViewModel(IDIContainer container, IAuthorizationManager authManager, INavigationService navigationService)
        {
            _authManager = authManager;
            _navigationService = navigationService;
            var client = Container.Resolve<IClient>();

            InvalidUsernamePasswordVisibility = false;
            LoginTapped = container.Resolve<IRelayCommand<object>>();
            LoginTapped.ExecuteAction = async b =>
            {
                InvalidUsernamePasswordVisibility = false;

                var loginResult = await client.Login(Authorization, CancellationToken.None);
                InvalidUsernamePasswordVisibility = !loginResult.Success;

                if (loginResult.Success)
                {
                    Container.RegisterInstance<IClient>(client, "Session");
                    Container.RegisterInstance<IAuthorization>(loginResult.Response, "Session");
                    await _authManager.SaveAuthorization(loginResult.Response);
                    _navigationService.Navigate(this, "LoginComplete", client);
                }
            };

            WebViewOnNavigationStarting = container.Resolve<IRelayCommand<string>>();
            WebViewOnNavigationStarting.ExecuteAction = async b =>
            {
                var uri = b;

                if (b.ToLower().Contains("access_token="))
                {
                    var u = new Uri(uri, UriKind.RelativeOrAbsolute);
                    //#access_token=7e203d21-a689-4da0-aac3-d1b576eded2c&token_type=bearer&expires_in=43200
                    var fragments = ParseFragment(u.Fragment);

                    var auth = Container.Resolve<IAuthorization>();
                    if (fragments.ContainsKey("access_token"))
                    {
                        auth.AccessToken = fragments["access_token"];
                    }
                    if (fragments.ContainsKey("token_type"))
                    {
                        auth.TokenType = fragments["token_type"];
                    }
                    if (fragments.ContainsKey("expires_in"))
                    {
                        var expires = 0;
                        var expin = fragments["expires_in"];
                        int.TryParse(expin, out expires);
                        auth.ExpiresIn = expires;
                    }
                    auth.Success = true;

                    client.Authorization = auth;
                    Container.RegisterInstance(auth, "Session");
                    Container.RegisterInstance(client, "Session");
                    await _authManager.SaveAuthorization(auth);

                    _navigationService.Navigate(this, "LoginComplete", client);

                    LoginUrl = "https://www.moj.io";
                }
            };

            ResetLoginUrl();
        }

        public bool InvalidUsernamePasswordVisibility
        {
            get { return _invalidUsernamePasswordVisibility; }
            set
            {
                _invalidUsernamePasswordVisibility = value;
                OnPropertyChanged();
            }
        }

        public string UsernameLabel
        {
            get { return Localization.GetTranslation("Username"); }
        }

        public string LoginUrl
        {
            get { return _loginUrl; }
            set
            {
                _loginUrl = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand<string> WebViewOnNavigationStarting { get; }

        public string InvalidUsernamePassword
        {
            get { return Localization.GetTranslation("Invalid Username or Password"); }
        }

        public string PasswordLabel
        {
            get { return Localization.GetTranslation("Password"); }
        }

        public string LoginButtonLabel
        {
            get { return Localization.GetTranslation("Login >>"); }
        }

        public IRelayCommand<object> LoginTapped { get; }

        public void ResetLoginUrl()
        {
            var client = Container.Resolve<IClient>();
            LoginUrl = string.Format("{0}oauth2/authorize?response_type=token&redirect_uri={1}&realm=mojiosdk&client_id={2}&scope=full", client.Configuration.Environment.AccountsUri, WebUtility.UrlEncode(client.Configuration.RedirectUri), WebUtility.UrlEncode(client.Configuration.ClientId));
        }

        private Dictionary<string, string> ParseFragment(string fragment)
        {
            var dict = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(fragment)) return dict;
            if (fragment.StartsWith("#")) fragment = fragment.Substring(1);
            var pairs = fragment.Split('&');
            foreach (var p in pairs)
            {
                var parts = p.Split('=');
                var key = parts[0].Trim('?', ' ');
                var val = parts[1].Trim();

                dict.Add(key, val);
            }
            return dict;
        }
    }
}