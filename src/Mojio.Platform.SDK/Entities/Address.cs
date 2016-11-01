using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Address : IAddress
    {
        public string HouseNumber { get; set; }
        public string Road { get; set; }
        public string Neighbourhood { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string FormattedAddress { get; set; }
    }
}