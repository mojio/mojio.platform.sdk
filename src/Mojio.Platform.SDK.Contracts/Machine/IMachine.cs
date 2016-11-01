using Mojio.Platform.SDK.Contracts.Client;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Contracts.Machine
{
    public interface IMachine
    {
        IClient Client { get; set; }

        Task<IVehicleState> SendEvent(IVehicleState state, string IMEI, string Vin = null);

        Task<IMachineStates> SendEvents(IMachineStates states, string IMEI, string Vin = null, int sleepDuration = 0);
    }
}