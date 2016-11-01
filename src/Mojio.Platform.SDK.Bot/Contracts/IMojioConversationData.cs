using System.Collections.Generic;
using Mojio.Platform.SDK.Bot.Contracts;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public interface IMojioConversationData
    {
        IList<IIntent> Intents { get; set; }
        IList<IEntity> Entities { get; set; }
    }
}