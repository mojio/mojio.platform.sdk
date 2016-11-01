using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.SampleApp.Shared.Contracts
{
    public interface IHaveMe
    {
        IUser Me { get; set; }
    }
}