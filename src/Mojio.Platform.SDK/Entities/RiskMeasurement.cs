using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class RiskMeasurement : Measurement, IRiskMeasurement
    {
        public RiskSeverity RiskSeverity { get; set; }
    }
}