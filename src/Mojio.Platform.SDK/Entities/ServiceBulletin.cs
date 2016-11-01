using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class ServiceBulletin : IServiceBulletin
    {
        public string ItemNumber { get; set; }
        public string BulletinNumber { get; set; }
        public string ReplacementBulletinNumber { get; set; }
        public string DateAdded { get; set; }
        public string Component { get; set; }
        public string BulletinDate { get; set; }
        public string Summary { get; set; }
    }
}