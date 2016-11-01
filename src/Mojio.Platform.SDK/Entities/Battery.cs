using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Battery : RiskMeasurement, IBattery
    {
        public bool Connected { get; set; }
        public IMeasurement LowVoltageDuration { get; set; }
        public IMeasurement HighVoltageDuration { get; set; }
    }
}