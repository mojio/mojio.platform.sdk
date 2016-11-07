using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
  
    public class MongoDBTransport : BaseTransport, IMongoDBTransport
    {
        public string ConnectionString { get; set; }

        public string CollectionName { get; set; }
        public IdentifierType Identifier { get; set; }

        public override TransportTypes TransportType => TransportTypes.MongoDB;
        public override string Type => TransportTypes.MongoDB.ToString().ToLower();
    }
}
