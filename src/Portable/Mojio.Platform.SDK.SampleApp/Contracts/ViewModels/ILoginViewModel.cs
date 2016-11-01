using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;

namespace Mojio.Platform.SDK.SampleApp.Contracts.ViewModels
{
    public interface ILoginViewModel
    {
        string LoginUrl { get; set; }
        IAuthorization Authorization { get; set; }
        IRelayCommand<object> LoginTapped { get; }
        string InvalidUsernamePassword { get; }
        string PasswordLabel { get; }
        string LoginButtonLabel { get; }
        IRelayCommand<string> WebViewOnNavigationStarting { get; }

        void ResetLoginUrl();
    }
}