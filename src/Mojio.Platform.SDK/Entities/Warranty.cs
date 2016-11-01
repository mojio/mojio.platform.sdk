using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Warranty : IWarranty
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Months { get; set; }
        public float Km { get; set; }
    }
}