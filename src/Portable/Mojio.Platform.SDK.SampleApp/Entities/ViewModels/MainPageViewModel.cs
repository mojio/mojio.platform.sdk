using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.SampleApp.Entities.ViewModels
{
    public class MainPageViewModel : BaseViewModel, IMainPageViewModel, INavigationRequest
    {
        private string _displayName;

        public MainPageViewModel()
        {
            Client = Container.Resolve<IClient>("Session");
        }

        private IClient Client { get; }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public async Task Init()
        {
            var meResult = await Client.Me(CancellationToken.None);
            if (meResult.Success)
            {
                DisplayName = meResult.Response.UserName;
            }
        }

        public event NavigationRequested OnNavigationRequested;
    }
}