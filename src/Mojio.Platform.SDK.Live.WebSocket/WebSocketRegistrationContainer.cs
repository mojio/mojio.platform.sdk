using Mojio.Platform.SDK.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Live.WebSocket
{
    public class WebSocketRegistrationContainer : IRegistrationContainer
    {
        public void Register(IDIContainer container)
        {
            container.Register<IWatchVehicles, MojioWebSocket>();
            container.Register<IWatchActivities, MojioWebSocket>();
            container.Register<IWatchMojios, MojioWebSocket>();
        }
    }
}