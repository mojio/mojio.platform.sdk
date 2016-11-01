namespace Mojio.Platform.SDK.Contracts
{
    public interface IEnvironmentFactory
    {
        IEnvironment GetEnvironment(Environments environment);
    }
}