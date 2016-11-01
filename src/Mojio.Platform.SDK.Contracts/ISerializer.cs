namespace Mojio.Platform.SDK.Contracts
{
    public interface ISerializer : ISerialize, IDeserialize
    {
         string ContentType { get; }
    }
}