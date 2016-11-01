using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities.DI;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mojio.Platform.SDK.SampleApp.Entities.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly ILog _log;
        private readonly IDispatchService dispatchService;
        protected ILocalization Localization;

        public BaseViewModel()
        {
            _log = DIContainer.Current.Resolve<ILog>();

            Localization = DIContainer.Current.Resolve<ILocalization>();
            dispatchService = DIContainer.Current.Resolve<IDispatchService>();
            try
            {
                Authorization = DIContainer.Current.Resolve<IAuthorization>("Session");
                Client = Container.Resolve<IClient>("Session");
            }
            catch (Exception e)
            {
                _log.Info("No active session, {0}", e.ToString());
            }
            if (Authorization == null) Authorization = DIContainer.Current.Resolve<IAuthorization>();
            if (Client == null) Client = DIContainer.Current.Resolve<IClient>();
        }

        protected IClient Client { get; set; }

        public IDIContainer Container
        {
            get { return DIContainer.Current; }
        }

        public IAuthorization Authorization { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                dispatchService.Handler = PropertyChanged;
                await dispatchService.RunAsync(propertyName);
            }
        }
    }
}