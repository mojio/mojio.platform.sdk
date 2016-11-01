using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using Windows.UI.Xaml.Controls;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Mojio.Platform.SDK.SampleApp.Pages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page, IPage
    {
        private readonly ILoginViewModel viewModel = App.DiContainer.Resolve<ILoginViewModel>();

        public Login()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}