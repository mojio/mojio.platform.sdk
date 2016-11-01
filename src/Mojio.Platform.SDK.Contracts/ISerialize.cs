namespace Mojio.Platform.SDK.Contracts
{
    public interface ISerialize
    {
        string ContentType { get; }

        byte[] Serialize(object entity);

        string SerializeToString(object entity);
    }
}