using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Email : IEmail
    {
        public bool Verified { get; set; }
        public string Address { get; set; }
    }
}