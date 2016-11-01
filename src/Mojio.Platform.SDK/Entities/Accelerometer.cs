using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Accelerometer : IAccelerometer
    {
        public IMeasurement X { get; set; }
        public IMeasurement Y { get; set; }
        public IMeasurement Z { get; set; }
        public IMeasurement Magnitude { get; set; }
        public IMeasurement SamplingInterval { get; set; }
    }
}