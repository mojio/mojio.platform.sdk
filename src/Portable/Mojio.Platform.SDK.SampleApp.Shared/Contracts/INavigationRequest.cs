namespace Mojio.Platform.SDK.SampleApp.Shared.Contracts
{
    public delegate void NavigationRequested(object sender, string key, object state);

    public interface INavigationRequest
    {
        event NavigationRequested OnNavigationRequested;
    }
}