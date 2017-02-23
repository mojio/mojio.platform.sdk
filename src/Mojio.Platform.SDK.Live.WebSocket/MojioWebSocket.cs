#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Contracts.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Live.WebSocket
{
    public class MojioWebSocket : IWatchVehicles, IWatchMojios, IWatchActivities
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
        private string _entityId;

        private bool _connected = false;

        private ObserverEntity _entity = ObserverEntity.Vehicles;

        public MojioWebSocket(IDIContainer contaner,
            ISerializer serializer, ILog log,
            IObservable<IVehicle> vehicleObservable,
            IObservable<IActivity> activityObservable,
            IObservable<IMojio> mojioObservable)
        {
            _contaner = contaner;
            _serializer = serializer;
            _log = log;

            _vehicleObservable = vehicleObservable;
            _activityObservable = activityObservable;
            _mojioObservable = mojioObservable;
        }

        private async Task WatchEntity(ObserverEntity entity, IClient client,
            string entityId = null, CancellationToken cancellationToken = default(CancellationToken),
            Action<IVehicle> changedAction = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (changedAction == null) throw new ArgumentNullException(nameof(changedAction));
            if (_connected) throw new Exception("Cant setup more than watch per instance.");

            _entity = entity;
            _connected = true;
            _entityId = entityId;
            _changedAction = changedAction;
            _cancellationToken = cancellationToken;
            _client = client;

            Task.Factory.StartNew(MonitorReceive, TaskCreationOptions.LongRunning);
        }

        public async Task<IObservable<IVehicle>> WatchVehicles(IClient client, string vehicleId = null, CancellationToken cancellationToken = default(CancellationToken), Action<IVehicle> changedAction = null)
        {
            await WatchEntity(ObserverEntity.Vehicles, client, vehicleId, cancellationToken, changedAction);
            return _vehicleObservable;
        }

        private async Task Connect()
        {
            try
            {
                var uri = _client.WebSocketObserverUri(_entity, _entityId);
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

        public async Task<IObservable<IMojio>> WatchMojios(IClient client, string mojioId = null, CancellationToken cancellationToken = new CancellationToken(),
            Action<IVehicle> changedAction = null)
        {
            await WatchEntity(ObserverEntity.Mojios, client, mojioId, cancellationToken, changedAction);
            return _mojioObservable;
        }

        public async Task<IObservable<IActivity>> WatchActivities(IClient client, CancellationToken cancellationToken = new CancellationToken(),
            Action<IVehicle> changedAction = null)
        {
            await WatchEntity(ObserverEntity.Activities, client, null, cancellationToken, changedAction);
            return _activityObservable;
        }

        public async Task<IObservable<IMojio>> WatchUsers(IClient client, string mojioId = null, CancellationToken cancellationToken = new CancellationToken(),
            Action<IVehicle> changedAction = null)
        {
            await WatchEntity(ObserverEntity.Users, client, mojioId, cancellationToken, changedAction);
            return _mojioObservable;
        }
    }
}