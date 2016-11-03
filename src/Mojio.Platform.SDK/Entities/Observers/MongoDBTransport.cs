using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
  
    public class MongoDBTransport : BaseTransport, IMongoDBTransport
    {
        public MongoDBTransport()
        {
            TransportType = TransportTypes.MongoDB;
        }
        public string ConnectionString { get; set; }

        public string CollectionName { get; set; }
        public IdentifierType Identifier { get; set; }


    }
}
