using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Mojio.Platform.SDK.SampleApp.Pages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OAuthLogin : Page, IPage
    {
        private readonly ILog _log = DIContainer.Current.Resolve<ILog>();
        private readonly ILoginViewModel viewModel = DIContainer.Current.Resolve<ILoginViewModel>();

        public OAuthLogin()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel.ResetLoginUrl();
            base.OnNavigatedTo(e);
        }

        private void WebView_OnNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            viewModel.WebViewOnNavigationStarting.ExecuteAction(args.Uri.ToString());
        }

        private void WebView_OnNavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            _log.Debug(e);
            //(sender as WebView).Navigate(e.Uri);
        }
    }
}