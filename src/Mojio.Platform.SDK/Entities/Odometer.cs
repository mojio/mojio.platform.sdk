using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Odometer : Measurement, IOdometer

    {
        public long RolloverValue { get; set; }
    }
}