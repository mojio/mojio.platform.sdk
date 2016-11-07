using Mojio.Platform.SDK.Contracts.Push;

namespace Mojio.Platform.SDK.Entities.Observers
{
    public class MqttTransport : BaseTransport, IMqttTransport
    {
        public const int DefaultPort = 1883;

        public string HostName { get; set; }
        public int? Port { get; set; }

        public string ClientId { get; set; } = "mojio-api-v2";

        public string Topic { get; set; } 

        public string UserName { get; set; }

        public string Password { get; set; }

        public override TransportTypes TransportType => TransportTypes.Mqtt;
        public override string Type => TransportTypes.Mqtt.ToString().ToLower();
    }
}
