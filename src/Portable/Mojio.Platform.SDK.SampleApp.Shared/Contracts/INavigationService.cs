namespace Mojio.Platform.SDK.SampleApp.Shared.Contracts
{
    public interface INavigationService
    {
        bool Navigate(object sender, string completedAction, object state);
    }
}