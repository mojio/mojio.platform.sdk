using System.Threading.Tasks;

namespace Mojio.Platform.SDK.SampleApp.Contracts.ViewModels
{
    public interface IMainPageViewModel
    {
        string DisplayName { get; set; }

        Task Init();
    }
}