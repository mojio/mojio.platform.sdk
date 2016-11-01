using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.SampleApp.Contracts.ViewModels;
using Mojio.Platform.SDK.SampleApp.Entities;
using Mojio.Platform.SDK.SampleApp.Entities.ViewModels;
using Mojio.Platform.SDK.SampleApp.Pages;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.SampleApp
{
    public class UIRegistrationContainer : IRegistrationContainer
    {
        public void Register(IDIContainer container)
        {
            container.Register<IPage, MainPage>("MainPage");
            container.Register<IPage, Dashboard>("Dashboard");

#if OAUTH
            container.Register<IPage, OAuthLogin>("Login");

#else
            container.Register<IPage, Login>("Login");
#endif

            container.Register<INavigationService, DefaultNavigationService>();
            container.Register<IDispatchService, UniversalDispatchService>();

            container.Register<ILoginViewModel, LoginViewModel>();
            container.Register<IDashboardViewModel, DashboardViewModel>();
            container.Register<IMainPageViewModel, MainPageViewModel>();

            container.Register<IActivityStreamViewModel, ActivityStreamViewModel>();
            container.Register<IActivityViewModel, ActivityViewModel>();

#if CACHE_ENABLED
            container.Unregister<ICache>();
            container.Register<ICache, StorageCache>();
#endif
        }
    }
}