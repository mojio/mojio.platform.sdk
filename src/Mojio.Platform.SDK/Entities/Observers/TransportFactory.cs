using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class TransportFactory : ITransportFactory
    {
        private readonly IDeserialize _serializer;
        private readonly IDIContainer _container;

        public TransportFactory(IDeserialize serializer, IDIContainer container)
        {
            _serializer = serializer;
            _container = container;
        }

        public ITransport GetTransport(TransportTypes type)
        {
            return _container.Resolve<ITransport>(type.ToString());
        }

        public ITransport GetTransport(string json)
        {
            var baseTransport = _serializer.Deserialize<ITransport>(json);
            var type = _container.Resolve<ITransport>(baseTransport.TransportType.ToString());

            return _serializer.Deserialize(json, type.GetType()) as ITransport;
        }
    }
}
