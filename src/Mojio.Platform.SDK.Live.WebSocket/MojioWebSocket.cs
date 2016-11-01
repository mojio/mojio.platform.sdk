using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Live.WebSocket
{
    public class MojioWebSocket : IWatchVehicles
    {
        private readonly IDIContainer _contaner;
        private const int ReceiveChunkSize = 2048;
        private Action<IVehicle> _changedAction = null;
        private ClientWebSocket _socket = null;
        private IClient _client = null;
        private CancellationToken _cancellationToken;
        private ISerializer _serializer;
        private readonly ILog _log;
        private IObservable<IVehicle> _vehicleObservable;
        private IObservable<IActivity> _activityObservable;
        private IObservable<IMojio> _mojioObservable;

        public MojioWebSocket(IDIContainer contaner, ISerializer serializer, ILog log,
            IObservable<IVehicle> vehicleObservable, IObservable<IActivity> activityObservable,
            IObservable<IMojio> mojioObservable)
        {
            _contaner = contaner;
            _serializer = serializer;
            _log = log;

            _vehicleObservable = vehicleObservable;
            _activityObservable = activityObservable;
            _mojioObservable = mojioObservable;
        }

        public async Task<IObservable<IVehicle>> WatchVehicles(IClient client, CancellationToken cancellationToken, Action<IVehicle> changedAction = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (changedAction == null) throw new ArgumentNullException(nameof(changedAction));
            _changedAction = changedAction;
            _cancellationToken = cancellationToken;
            _client = client;

            Task.Factory.StartNew(MonitorReceive, TaskCreationOptions.LongRunning);

            return _vehicleObservable;
        }

        private async Task Connect()
        {
            try
            {
                var uri = _client.WebSocketObserverUri();
                _socket = new ClientWebSocket();
                _socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
                _socket.Options.SetRequestHeader("Authorization", $"Bearer {_client.Authorization.MojioApiToken}");
                await _socket.ConnectAsync(uri, _cancellationToken);
                _log.Debug($"Connected to web socket at {uri}");
            }
            catch (Exception e)
            {
                _log.Error(e);
            }
        }

        private async Task MonitorReceive()
        {
            if (_socket == null)
            {
                await Connect();
            }
            string prevResult = "";
            var buffer = new byte[ReceiveChunkSize];
            try
            {
                while (_socket.State == WebSocketState.Open)
                {
                    var stringResult = new StringBuilder();

                    WebSocketReceiveResult result;

                    do
                    {
                        result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationToken);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                            //CallOnDisconnected();
                        }
                        else
                        {
                            var str = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            stringResult.Append(str);
                        }
                    } while (!result.EndOfMessage);

                    if (!prevResult.Equals(stringResult.ToString()))
                    {
                        prevResult = stringResult.ToString();
                        if (_changedAction != null)
                        {
                            var newVehicle = _serializer.Deserialize<IVehicle>(stringResult.ToString());
                            if (newVehicle != null)
                            {
                                if (_changedAction != null) _changedAction(newVehicle);

                                //if (_vehicleObservable != null) _vehicleObservable.OnNext(newVehicle);
                            }
                        }
                        //CallOnMessage(stringResult);
                    }
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {
                //CallOnDisconnected();
            }
            finally
            {
                _socket.Dispose();
            }
        }
    }
}