using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;

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

    public class Links : Dictionary<string, string>, ILinks
    {
        
    }
}