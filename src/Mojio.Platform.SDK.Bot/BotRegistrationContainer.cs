using Mojio.Platform.SDK.Bot.Contracts;
using Mojio.Platform.SDK.Bot.Entities;
using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.Bot
{
    public class BotRegistrationContainer : IRegistrationContainer
    {
        public void Register(IDIContainer container)
        {
            container.Register<IAttachment, Attachment>();
            container.Register<IBotClient, BotClient>();
            container.Register<IChannelAccount, ChannelAccount>();
            container.Register<ILocation, Location>();
            container.Register<IMention, Mention>();
            container.Register<IMessage, Message>();
            container.Register<IMojioConversationData, MojioConversationData>();
            container.Register<IEntity, Entity>();
            container.Register<IIntent, Intent>();

            var botAccount = container.Resolve<IChannelAccount>();
            botAccount.Id = "kitt-mojio-1";
            botAccount.Address = "1080 Howe Street, Vancouver, BC Canada";
            botAccount.IsBot = true;
            botAccount.Name = "Kitt";
            container.RegisterInstance(botAccount, "bot");

        }
    }
}