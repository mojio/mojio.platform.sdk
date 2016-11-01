using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Transmission : ITransmission
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DetailType { get; set; }
        public string Gears { get; set; }
    }
}