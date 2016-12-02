using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Machine;
using Mojio.Platform.SDK.Contracts.Push;
using Mojio.Platform.SDK.Entities.DI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IGroup = Mojio.Platform.SDK.Contracts.Entities.IGroup;
using IImage = Mojio.Platform.SDK.Contracts.Entities.IImage;

namespace Mojio.Platform.SDK.SimpleClient
{
    public class SimpleClient : IClient
    {
        private readonly IAuthorizationManager _authManager;
        private readonly Environments _environment;

        public SimpleClient(Environments environment, IConfiguration configuration
            )
        {
            _environment = environment;
            Configuration = configuration;

            var factory = DIContainer.Current.Resolve<IEnvironmentFactory>();
            var ee = factory.GetEnvironment(environment);
            configuration.Environment = ee;
            DIContainer.Current.RegisterInstance(ee);
            DIContainer.Current.RegisterInstance(ee, environment.ToString());
            DIContainer.Current.RegisterInstance(configuration);

			SdkClient = DIContainer.Current.Resolve<IClient>();
//            var serializer = DIContainer.Current.Resolve<ISerializer>();
//            var log = DIContainer.Current.Resolve<Contracts.Instrumentation.ILog>();
            //			SdkClient = new Client(
            //				DIContainer.Current,
            //				configuration,
            //				DIContainer.Current.Resolve<IHttpClientBuilder>(),
            ////				new MojioHttpClient(
            ////					DIContainer.Current.Resolve<IAuthorization>(),
            ////					configuration, 
            ////					serializer, 
            ////					DIContainer.Current, 
            ////					log
            ////				), 
            //				log,
            //				serializer,
            //				DIContainer.Current.Resolve<ICache>());

            _authManager = DIContainer.Current.Resolve<IAuthorizationManager>();
        }

        public IClient SdkClient { get; set; }
        public static IDIContainer Container { get; set; } = DIContainer.Current;
        public IProgress<ISDKProgress> DefaultProgress { get; set; }
        public CancellationToken DefaultCancellationToken { get; set; }
        public IConfiguration Configuration { get; set; }

        public async Task<IPlatformResponse<IAuthorization>> Login(string mojioApiToken, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            if (this.Authorization == null) this.Authorization = new CoreAuthorization();
            this.Authorization.MojioApiToken = mojioApiToken;
            this.Authorization.ExpiresIn = int.MaxValue;
            return await SdkClient.Login(this.Authorization);
        }

        public IAuthorization Authorization { get; set; }

        public async Task<IPlatformResponse<IAppResponse>> Apps(int skip = 0, int top = 1000, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);

            return await SdkClient.Apps(skip, top, filter, select, orderby, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IApp>> CreateApp(IApp application, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.CreateApp(application, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IList<string>>> SaveTag(TagEntities entityType, Guid entityId, string tag, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.SaveTag(entityType, entityId, tag, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteTag(TagEntities entityType, Guid entityId, string tag, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteTag(entityType, entityId, tag, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteApp(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteApp(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IApp>> UpdateApp(IApp app, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.UpdateApp(app, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IImage>> GetImage(ImageEntities entityType, Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetImage(entityType, id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IActivityStreamApiResponse>> UserActivityStream(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.UserActivityStream(cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteImage(ImageEntities entityType, Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteImage(entityType, id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> SaveImage(ImageEntities entityType, Guid id, byte[] image, string fileName, string contentType, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.SaveImage(entityType, id, image, fileName, contentType, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> GetAppSecret(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetAppSecret(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteAppSecret(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteAppSecret(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IAuthorization>> Login(string username, string password, string scope = "full", CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SdkClient = Container.Resolve<IClient>();
            var result = await SdkClient.Login(username, password, scope, cancellationToken, progress);
            Authorization = result.Response;

            if (!string.IsNullOrEmpty(Authorization?.MojioApiToken) && !Authorization.HasExpired && _authManager != null)
            {
                await _authManager.SaveAuthorization(result.Response);
            }
            return result;
        }

        public async Task<IPlatformResponse<IAuthorization>> Login(IAuthorization authorization, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            var result = await SdkClient.Login(authorization, cancellationToken, progress);

            Authorization = result.Response;

            if (_authManager != null && (authorization?.Signature != Authorization?.Signature) && !string.IsNullOrEmpty(authorization?.Signature) && !string.IsNullOrEmpty(Authorization?.Signature))
            {
                await _authManager.SaveAuthorization(Authorization);
            }

            return result;
        }

        public async Task<IPlatformResponse<IMessageResponse>> Register(string email, string password, string username = null, string mobileNumber = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Register(email, password, username, mobileNumber, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IUser>> Me(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Me(cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IUser>> GetUser(Guid userId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetUser(userId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IList<IPushObserver>>> GetObservers(ObserverEntity entity, Guid? entityId = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetObservers(entity, entityId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> DeleteObserver(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteObserver(entity, key, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> GetObserver(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetObserver(entity, key, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IList<ITransport>>> GetObserverTransports(ObserverEntity entity, string key, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetObserverTransports(entity, key, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<TTr>> AddObserverTransport<TTr>(ObserverEntity entity, string observerKey, ITransport transport, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null) where TTr : ITransport
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.AddObserverTransport<TTr>(entity, observerKey, transport, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<TTr>> AddOrUpdateObserverTransport<TTr>(ObserverEntity entity, string observerKey, ITransport transport, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null) where TTr : ITransport
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.AddOrUpdateObserverTransport<TTr>(entity, observerKey, transport, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> DeleteObserverTransport(ObserverEntity entity, string observerKey, string transportKey, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteObserverTransport(entity, observerKey, transportKey, cancellationToken, progress);
        }

        public Uri WebSocketObserverUri(ObserverEntity entity = ObserverEntity.Vehicles, string id = null)
        {
            return SdkClient.WebSocketObserverUri(entity, id);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> Observe(ObserverEntity entity, Guid? entityId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Observe(entity, entityId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveMojio(Guid mojioId, IPushObserver observer,  CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.ObserveMojio(mojioId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveUser(Guid userId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.ObserveUser(userId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IPushObserverResponse>> ObserveVehicle(Guid vehicleId, IPushObserver observer, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.ObserveVehicle(vehicleId, observer, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVehicleLocationResponse>> TripHistoryLocations(string tripId, int skip = 0, int top = 10, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.TripHistoryLocations(tripId, skip, top, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVehiclesResponse>> TripHistoryStates(string tripId, int skip = 0, int top = 1000, string fields = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.TripHistoryStates(tripId, skip, top, fields, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<ITrip>> UpdateTripName(string tripId, string name, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.UpdateTripName(tripId, name, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<ITrip>> GetTrip(string tripId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GetTrip(tripId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteTrip(string tripId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteTrip(tripId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<ITripsResponse>> Trips(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Trips(skip, top, filter, select, orderby, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMojioResponse>> Mojios(int skip = 0, int top = 1000, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Mojios(skip, top, filter, select, orderby, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMojio>> ClaimMojio(string imei, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.ClaimMojio(imei, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMojio>> RenameMojio(Guid id, string name, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.RenameMojio(id, name, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteMojio(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteMojio(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVehiclesResponse>> Vehicles(int skip = 0, int top = 1000, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null, bool skipCache = false)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Vehicles(skip, top, filter, select, orderby, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVehiclesResponse>> VehicleHistoryStates(Guid vehicleId, int skip = 0, int top = 10, string fields = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.VehicleHistoryStates(vehicleId, skip, top, fields, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVinDetails>> VehicleVinLookup(Guid vehicleId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.VehicleVinLookup(vehicleId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IServiceScheduleResponse>> VehicleNextService(Guid vehicleId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.VehicleNextService(vehicleId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<ITripsResponse>> VehicleTrips(Guid vehicleId, int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.VehicleTrips(vehicleId, skip, top, filter, select, orderby, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVehicleLocationResponse>> VehicleLocations(Guid vehicleId, int skip = 0, int top = 10, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.VehicleLocations(vehicleId, skip, top, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IVehicle>> CreateNewVehicle(IVehicle vehicle, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.CreateNewVehicle(vehicle, cancellationToken, progress);
        }

        public async Task<byte[]> DownloadImage(IImage image, ImageType type = ImageType.Thumbnail)
        {
            if (image == null) return null;

            var url = image.Thumbnail;
            if (type == ImageType.Normal) url = image.Normal;
            if (type == ImageType.Src) url = image.Src;
            if (string.IsNullOrEmpty(url)) return null;

            var downloadClient = new HttpClient();
            return await downloadClient.GetByteArrayAsync(url);
        }

        public async Task<IPlatformResponse<string>> Simulate(IMachineRequest request, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Simulate(request, cancellationToken, progress);
        }

        private void SetupTokenAndProgress(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            if (progress == null) progress = DefaultProgress;
            if (cancellationToken == null) cancellationToken = DefaultCancellationToken;
        }

        public async Task<IPlatformResponse<IGroupResponse>> Groups(CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Groups(cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IGroup>> Group(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.Group(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IList<string>>> GroupUsers(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.GroupUsers(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteGroup(Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.DeleteGroup(id, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> UpdateGroup(Guid id, IGroup @group, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.UpdateGroup(id, @group, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IGroup>> CreateGroup(IGroup @group, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.CreateGroup(@group, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IMessageResponse>> RemoveUserFromGroup(Guid id, Guid userId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.RemoveUserFromGroup(id, userId, cancellationToken, progress);
        }

        public async Task<IPlatformResponse<IList<string>>> AddUserToGroup(Guid id, IList<Guid> users, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            SetupTokenAndProgress(cancellationToken, progress);
            return await SdkClient.AddUserToGroup(id, users, cancellationToken, progress);
        }
    }
}