namespace Mojio.Platform.SDK.Contracts.Push
{
    public interface ITransportFactory
    {
        ITransport GetTransport(TransportTypes type);
        ITransport GetTransport(string json);
    }
}