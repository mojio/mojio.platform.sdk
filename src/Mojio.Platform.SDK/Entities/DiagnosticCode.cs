using Mojio.Platform.SDK.Contracts.Entities;
using System;

namespace Mojio.Platform.SDK.Entities
{
    public class DiagnosticCode : IDiagnosticCode
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Severity { get; set; }
        public string Instructions { get; set; }
    }
}