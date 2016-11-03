using Mojio.Platform.SDK.Contracts;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Bot.Contracts
{
    public enum SystemCommand
    {
        Ping,
        DeleteUserData,
        BotAddedToConversation,
        UserAddedToConversation,
        UserRemovedFromConversation,
        EndOfConversation,
        Message
    }

    public interface IBotClient
    {
        string Url { get; set; }

        Task<IPlatformResponse<IMessage>> SendMessage(IMessage input, string mojioApiToken = null);
    }
}