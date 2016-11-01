using System.ComponentModel;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.SampleApp.Shared.Contracts
{
    public interface IDispatchService
    {
        PropertyChangedEventHandler Handler { get; set; }

        Task RunAsync(string propertyName);
    }
}