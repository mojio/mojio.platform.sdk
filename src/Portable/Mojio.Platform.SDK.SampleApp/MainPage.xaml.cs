using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mojio.Platform.SDK.SampleApp
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IPage
    {
        private readonly IMainPageViewModel viewModel = App.DiContainer.Resolve<IMainPageViewModel>();

        public MainPage()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await viewModel.Init();
        }

        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var d = new ContentDialog();
            d.Title = "Not implemented";
            d.Content = "The buttons are for illustrative purposes only and do not perform any action";
            d.PrimaryButtonText = "OK";
            await d.ShowAsync();
        }
    }
}