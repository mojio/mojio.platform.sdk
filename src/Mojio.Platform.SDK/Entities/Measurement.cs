using Mojio.Platform.SDK.Contracts.Entities;
using System;

namespace Mojio.Platform.SDK.Entities
{
    public class Measurement : IMeasurement
    {
        public string BaseUnit { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public float BaseValue { get; set; }
        public string Unit { get; set; }
        public float Value { get; set; }
    }
}