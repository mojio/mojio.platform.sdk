using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Entities.ViewModels;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Mojio.Platform.SDK.SampleApp.Pages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Page, IPage
    {
        private readonly IDashboardViewModel viewModel = App.DiContainer.Resolve<IDashboardViewModel>();

        public Dashboard()
        {
            InitializeComponent();

            DataContext = viewModel;

            VehiclesMap.DashboardViewModel = viewModel;

            //(viewModel as BaseViewModel).PropertyChanged += Dashboard_PropertyChanged;
        }

        private void Dashboard_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}