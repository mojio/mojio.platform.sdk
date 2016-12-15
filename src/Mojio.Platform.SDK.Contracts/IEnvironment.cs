namespace Mojio.Platform.SDK.Contracts
{
    public enum Environments
    {
        //traffic manager url
        Production,

        //traffic manager url
        Staging,

        //direct url
        Trial,

        //direct url
        NaProduction,

        //direct url
        EuProduction,

        //direct url
        NaStaging,

        //direct url
        EuStaging,

        //internal mojio testing
        Develop,

        Load

    }

    public interface IEnvironment
    {
        Environments SelectedEnvironment { get; set; }
        string AccountsUri { get; set; }
        string APIUri { get; set; }
        string ImagesUri { get; set; }
        string PushUri { get; set; }
    }
}