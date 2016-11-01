using System.Collections.Generic;
using Mojio.Platform.SDK.Bot.Contracts;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class MojioConversationData : IMojioConversationData
    {
        public IList<IIntent> Intents { get; set; }
        public IList<IEntity> Entities { get; set; }
    }
}
