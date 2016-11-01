using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.SampleApp.Shared.Contracts;
using Windows.UI.Xaml.Controls;

namespace Mojio.Platform.SDK.SampleApp.Entities
{
    public class DefaultNavigationService : INavigationService
    {
        private readonly IDIContainer _container;
        private readonly Frame rootFrame;

        public DefaultNavigationService(IDIContainer container)
        {
            _container = container;
            rootFrame = container.Resolve<Frame>("RootFrame");
        }

        public bool Navigate(object sender, string completedAction, object state)
        {
            rootFrame.BackStack.Clear();
            IPage page = null;
            switch (completedAction)
            {
                case "LoginComplete":
                    page = _container.Resolve<IPage>("Dashboard");
                    break;

                default: //Login, Logout
                    page = _container.Resolve<IPage>("Login");
                    break;
            }
            return rootFrame.Navigate(page.GetType(), state);
        }
    }
}