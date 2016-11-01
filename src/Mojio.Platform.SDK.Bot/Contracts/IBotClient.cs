using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;

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
        Task<IPlatformResponse<IMessage>> SendMessage(IMessage input, string mojioApiToken = null);
    }
}