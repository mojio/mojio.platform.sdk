using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Contracts.Machine;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Entities.Machine
{
    public class HttpMachine : IMachine
    {
        private readonly IDIContainer _container;
        private readonly ILog _log;

        public HttpMachine(IDIContainer container, ILog log)
        {
            _container = container;
            _log = log;
        }

        public IClient Client { get; set; }

        public async Task<IVehicleState> SendEvent(IVehicleState state, string IMEI, string Vin = null)
        {
            var simulatedEvent = _container.Resolve<IMachineRequest>();
            simulatedEvent.IMEI = IMEI;
            simulatedEvent.DeviceTime = DateTimeOffset.UtcNow;
            simulatedEvent.Vehicle = state.Vehicle;
            simulatedEvent.TelematicDevice = state?.TelematicDevice;
            if (simulatedEvent.TelematicDevice == null)
            {
                simulatedEvent.TelematicDevice = _container.Resolve<IMachineTelematicDevice>();
            }
            simulatedEvent.Vehicle.VIN = Vin;
            simulatedEvent.TelematicDevice.IMEI = IMEI;

            var result = await Client.Simulate(simulatedEvent);

            if (result.Success)
            {
                var id = Guid.Empty;
                Guid.TryParse(result.Response, out id);
                state.MessageId = id;
            }
            return state;
        }

        public async Task<IMachineStates> SendEvents(IMachineStates states, string IMEI, string Vin = null, int sleepDuration = 0)
        {
            var first = true;
            var goodStates = from s in states.VehicleStates where s.Vehicle != null select s;
            var max = goodStates.Count();

            foreach (var state in goodStates)
            {
                if (state.Vehicle != null)
                {
                    var simulatedEvent = PrepareStateRequest(state, IMEI, Vin, true, first);
                    first = false;
                    var result = await Client.Simulate(simulatedEvent);
                    if (result.Success)
                    {
                        var id = Guid.Empty;
                        Guid.TryParse(result.Response, out id);
                        state.MessageId = id;
                    }
                    _log.Debug(new { result.Response, IMEI, simulatedEvent.Vehicle.Location, simulatedEvent.Vehicle.IgnitionState.Value, simulatedEvent.EventCode, Vin, simulatedEvent.DeviceTime, result });
                    if (sleepDuration > 0)
                    {
                        await Task.Delay(sleepDuration);
                    }
                }
            }
            return states;
        }

        private IMachineRequest PrepareStateRequest(IVehicleState state, string IMEI, string Vin = null, bool ignitionState = true, bool isFirstMessage = false)
        {
            var simulatedEvent = _container.Resolve<IMachineRequest>();
            simulatedEvent.IMEI = IMEI;
            simulatedEvent.DeviceTime = DateTimeOffset.UtcNow;
            simulatedEvent.Vehicle = state.Vehicle;

            if (simulatedEvent.Vehicle.IgnitionState == null) simulatedEvent.Vehicle.IgnitionState = _container.Resolve<IState>();
            simulatedEvent.Vehicle.IgnitionState.Value = ignitionState;
            if (isFirstMessage)
            {
                simulatedEvent.EventCode = 6010; //6010 vehicle switch
            }
            else
            {
                simulatedEvent.EventCode = 4050; //4050 regular driving status update
            }
            simulatedEvent.TelematicDevice = state?.TelematicDevice;
            if (simulatedEvent.TelematicDevice == null)
            {
                simulatedEvent.TelematicDevice = _container.Resolve<IMachineTelematicDevice>();
            }
            simulatedEvent.Vehicle.VIN = Vin;
            simulatedEvent.TelematicDevice.IMEI = IMEI;

            return simulatedEvent;
        }
    }
}