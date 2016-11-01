using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Heading : Measurement, IHeading
    {
        public string Direction { get; set; }
        public bool LeftTurn { get; set; }
    }
}