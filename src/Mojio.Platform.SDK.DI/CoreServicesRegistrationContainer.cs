using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.ActivityStreams;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Contracts.Machine;
using Mojio.Platform.SDK.Contracts.Push;
using Mojio.Platform.SDK.Entities.ActivityStreams;
using Mojio.Platform.SDK.Entities.Environments;
using Mojio.Platform.SDK.Entities.Instrumentation;
using Mojio.Platform.SDK.Entities.Machine;
using Mojio.Platform.SDK.Entities.Observers;
using System;
using Environment = Mojio.Platform.SDK.Entities.Environments.Environment;
using IContractResolver = Newtonsoft.Json.Serialization.IContractResolver;
using IGroup = Mojio.Platform.SDK.Contracts.Entities.IGroup;
using IImage = Mojio.Platform.SDK.Contracts.Entities.IImage;
using ILocation = Mojio.Platform.SDK.Contracts.Entities.ILocation;
using IService = Mojio.Platform.SDK.Contracts.Entities.IService;
using VehicleState = Mojio.Platform.SDK.Entities.Machine.VehicleState;

namespace Mojio.Platform.SDK.Entities.DI
{
    public class CoreServicesRegistrationContainer : IRegistrationContainer
    {
        public void Register(IDIContainer container)
        {
            RegisterOverhead(container);
            RegisterSDKDomain(container);
        }

        private void RegisterSDKDomain(IDIContainer container)
        {
            container.Register<IUser, User>();
            container.Register<ITelephoneNumber, TelephoneNumber>();
            container.Register<IVehicle, Vehicle>();
            container.Register<IClient, Client>();
            container.Register<IClientApp, Client>();
            container.Register<IClientLogin, Client>();
            container.Register<IClientMe, Client>();
            container.Register<IClientTrip, Client>();
            container.Register<IClientMojio, Client>();
            container.Register<IClientVehicle, Client>();
            container.Register<IMachineRequest, MachineRequest>();

            container.Register<IImage, Image>();
            container.Register<IEmail, Email>();

            container.Register<IAccelerometer, Accelerometer>();
            container.Register<IAddress, Address>();
            container.Register<IBattery, Battery>();
            container.Register<IDiagnosticCode, DiagnosticCode>();
            container.Register<IHeading, Heading>();
            container.Register<ILocation, Location>();
            container.Register<IVirtualodometer, VirtualOdometer>();
            container.Register<IMeasurement, Measurement>();
            container.Register<IOdometer, Odometer>();
            container.Register<IRiskMeasurement, RiskMeasurement>();
            container.Register<IState, State>();
            container.Register<IVehiclesResponse, VehiclesResponse>();
            container.Register<IVinCommon, VinCommon>();
            container.Register<IVinDetails, VinDetails>();
            container.Register<IVinSummary, VinSummary>();
            container.Register<ITransmission, Transmission>();

            container.Register<ITripsResponse, TripsResponse>();
            container.Register<ITrip, Trip>();

            container.Register<IMojioResponse, MojioResponse>();
            container.Register<IMojio, Mojio>();

            container.Register<IEngine, Engine>();
            container.Register<IEngine, Engine>();
            container.Register<IWarranty, Warranty>();
            container.Register<IServiceBulletin, ServiceBulletin>();
            container.Register<IRecall, Recall>();
            container.Register<IServiceScheduleResponse, ServiceScheduleResponse>();
            container.Register<IService, Service>();

            container.Register<IApp, App>();
            container.Register<IAppResponse, AppResponse>();
            container.Register<IMessageResponse, MessageResponse>();

            container.Register<IVehicleLocationResponse, VehicleLocationResponse>();

            container.Register<IMachineStates, MachineStates>();
            container.Register<IMinMax, MinMax>();
            container.Register<IPoints, Points>();
            container.Register<IVehicleState, VehicleState>();
            container.Register<IMachineTelematicDevice, MachineTelematicDevice>();
            container.Register<IMachine, HttpMachine>();

            container.Register<ITransport, BaseTransport>();
            container.Register<ITransport, AndroidTransport>("Android");
            container.Register<ITransport, AppleTransport>("Apple");
            container.Register<ITransport, HttpPostTransport>("HttpPost");
            container.Register<ITransport, MongoDBTransport>("MongoDB");
            container.Register<ITransport, MqttTransport>("Mqtt");
            container.Register<ITransport, SignalRTransport>("SignalR");

            container.Register<AndroidTransport, AndroidTransport>();
            container.Register<AppleTransport, AppleTransport>();
            container.Register<HttpPostTransport, HttpPostTransport>();
            container.Register<MongoDBTransport, MongoDBTransport>();
            container.Register<MqttTransport, MqttTransport>();
            container.Register<SignalRTransport, SignalRTransport>();

            container.Register<IAndroidTransport, AndroidTransport>();
            container.Register<IAppleTransport, AppleTransport>();
            container.Register<IHttpPostTransport, HttpPostTransport>();
            container.Register<IMongoDBTransport, MongoDBTransport>();
            container.Register<IMqttTransport, MqttTransport>();
            container.Register<ISignalRTransport, SignalRTransport>();

            container.Register<ITransportFactory, TransportFactory>();
            container.Register<IPushObserverResponse, PushObserverResponse>();
            container.Register<IPushObserver, PushObserverRequest>();
            container.Register<IGetPushObserverResponse, GetPushObserverResponse>();

            container.Register<IGroup, Group>();
            container.Register<IGroupResponse, GroupResponse>();

            container.Register(typeof(IObservable<>), typeof(SimpleObservable<>));

            var vehicles = container.Resolve<IObservable<IVehicle>>();
            container.RegisterInstance<IObservable<IVehicle>>(vehicles);

            var activities = container.Resolve<IObservable<IActivity>>();
            container.RegisterInstance<IObservable<IActivity>>(activities);

            var mojios = container.Resolve<IObservable<IMojio>>();
            container.RegisterInstance<IObservable<IMojio>>(mojios);

            RegisterActivityStreams(container);
        }

        private void RegisterActivityStreams(IDIContainer container)
        {
            container.Register<IActivityStreamApiResponse, ActivityStreamApiResponse>();
            container.Register<IApplication, Application>();
            container.Register<Contracts.ActivityStreams.IGroup, Entities.ActivityStreams.Group>();
            container.Register<IOrganization, Organization>();
            container.Register<IPerson, Person>();
            container.Register<IService, Service>();
            container.Register<IActivityObject, ActivityObject>();
            container.Register<ILink, Link>();
            container.Register<IActivity, Activity>();
            container.Register<IIntransitiveActivity, IntransitiveActivity>();
            container.Register<IActor, Actor>();
            container.Register<ICollection, Collection>();
            container.Register<IOrderedCollection, OrderedCollection>();
            container.Register<ICollectionPage, CollectionPage>();
            container.Register<IOrderedCollectionPage, OrderedCollectionPage>();
            container.Register<IAccept, Accept>();
            container.Register<IAdd, Add>();
            container.Register<IAnnounce, Announce>();
            container.Register<IArrive, Arrive>();
            container.Register<IBlock, Block>();
            container.Register<ICreate, Create>();
            container.Register<IDelete, Delete>();
            container.Register<IDislike, Dislike>();
            container.Register<IFlag, Flag>();
            container.Register<IFollow, Follow>();
            container.Register<IIgnore, Ignore>();
            container.Register<IInvite, Invite>();
            container.Register<IJoin, Join>();
            container.Register<ILeave, Leave>();
            container.Register<ILike, Like>();
            container.Register<IListen, Listen>();
            container.Register<IMove, Move>();
            container.Register<IOffer, Offer>();
            container.Register<IQuestion, Question>();
            container.Register<IReject, Reject>();
            container.Register<IRead, Read>();
            container.Register<IRemove, Remove>();
            container.Register<ITentativeReject, TentativeReject>();
            container.Register<ITentativeReject, TentativeReject>();
            container.Register<ITravel, Travel>();
            container.Register<IUndo, Undo>();
            container.Register<IUpdate, Update>();
            container.Register<IView, View>();
            container.Register<IRelationship, Relationship>();
            container.Register<TargetObject, TargetObject>();
            container.Register<TargetLink, TargetLink>();
            container.Register<IArticle, Article>();
            container.Register<IDocument, Document>();
            container.Register<IAudio, Audio>();
            container.Register<IImage, Image>();
            container.Register<IVideo, Video>();
            container.Register<INote, Note>();
            container.Register<IPage, Page>();
            container.Register<IEvent, Event>();
            container.Register<IPlace, Place>();
            container.Register<IMention, Mention>();
            container.Register<IProfile, Profile>();
            container.Register<IAttachment, Attachment>();
            container.Register<IAttributedTo, AttributedTo>();
            container.Register<IBcc, Bcc>();
            container.Register<IBto, Bto>();
            container.Register<ICc, Cc>();
            container.Register<ICurrent, Current>();
            container.Register<IFirst, First>();
            container.Register<IGenerator, Generator>();
            container.Register<IIcon, Icon>();
            container.Register<IImageImage, ImageImage>();
            container.Register<IInReplyTo, InReplyTo>();
            container.Register<IInstrument, Instrument>();
            container.Register<ILast, Last>();
            container.Register<Contracts.ActivityStreams.ILocation, ActivityStreams.Location>();
            container.Register<IItems, Items>();
            container.Register<IItemsOrderedList, ItemsOrderedList>();
            container.Register<IOneOf, OneOf>();
            container.Register<IAnyOf, AnyOf>();
            container.Register<IOrigin, Origin>();
            container.Register<NextCollectionPage, NextCollectionPage>();
            container.Register<INext, Next>();
            container.Register<IPrev, Prev>();
            container.Register<IPreview, Preview>();
            container.Register<IResult, Result>();
            container.Register<IReplies, Replies>();
            container.Register<IScope, Scope>();
            container.Register<ITag, TagObject>();
            container.Register<ITo, To>();
            container.Register<IUrl, Url>();
            container.Register<IPartOf, PartOf>();
            container.Register<ISubject, SubjectObject>();
            container.Register<IDescribes, Describes>();
            container.Register<ILanguageString, LanguageString>();
        }

        private void RegisterOverhead(IDIContainer container)
        {
            container.Register<IContractResolver, ContractResolver>();
            container.Register<IHttpClientBuilder, MojioHttpClient>();
            container.Register<IEnvironment, Environment>("Template");
            container.Register<IEnvironmentFactory, EnvironmentFactory>();
            container.Register<IAuthorization, CoreAuthorization>();
            container.Register(typeof(IPlatformResponse<>), typeof(PlatformResponse<>));
            container.Register<ISerializer, JSONSerializer>();
            container.Register<ISerialize, JSONSerializer>();
            container.Register<IDeserialize, JSONSerializer>();
            container.Register<IAuthorizationManager, CacheBasedAuthorizationManager>();
            container.Register(typeof(ICacheItem<>), typeof(CacheItem<>));

            container.Register<ILog, BroadcastLogger>();

            container.Register<ICache, NullCacheProvider>();
            container.Register<ILocationHelper, LocationHelper>();
            container.Register<ISDKProgress, DefaultSDKProgress>();
            container.Register<IProgressMonitor, MillisecondProgressMonitor>();
        }
    }
}