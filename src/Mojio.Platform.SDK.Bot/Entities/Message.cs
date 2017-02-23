#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using Mojio.Platform.SDK.Bot.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class Message : IMessage
    {
        public Message()
        {
            Type = SystemCommand.Message;
        }


        [JsonProperty(PropertyName = "type")]
        public SystemCommand? Type { get; set; } = SystemCommand.Message;

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "conversationId")]
        public string ConversationId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; set; } = DateTime.UtcNow;

        [JsonProperty(PropertyName = "sourceText")]
        public string SourceText { get; set; }

        [JsonProperty(PropertyName = "sourceLanguage")]
        public string SourceLanguage { get; set; } = "en";

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; } = "en";

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "attachments")]
        public IList<IAttachment> Attachments { get; set; } = new List<IAttachment>();

        [JsonProperty(PropertyName = "from")]
        public IChannelAccount From { get; set; } = new ChannelAccount();

        [JsonProperty(PropertyName = "to")]
        public IChannelAccount To { get; set; } = new ChannelAccount();

        [JsonProperty(PropertyName = "replyToMessageId")]
        public string ReplyToMessageId { get; set; }

        [JsonProperty(PropertyName = "participants")]
        public IList<IChannelAccount> Participants { get; set; } = new List<IChannelAccount>();

        [JsonProperty(PropertyName = "totalParticipants")]
        public int? TotalParticipants { get; set; }

        [JsonProperty(PropertyName = "mentions")]
        public IList<IMention> Mentions { get; set; } = new List<IMention>();

        [JsonProperty(PropertyName = "place")]
        public string Place { get; set; }

        [JsonProperty(PropertyName = "channelMessageId")]
        public string ChannelMessageId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "channelConversationId")]
        public string ChannelConversationId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty(PropertyName = "channelData")]
        public object ChannelData { get; set; }

        [JsonProperty(PropertyName = "botUserData")]
        public object BotUserData { get; set; }

        [JsonProperty(PropertyName = "botConversationData")]
        public IMojioConversationData BotConversationData { get; set; }

        [JsonProperty(PropertyName = "botPerUserInConversationData")]
        public object BotPerUserInConversationData { get; set; }

        [JsonProperty(PropertyName = "location")]
        public ILocation Location { get; set; } = new Location();

        [JsonProperty(PropertyName = "hashtags")]
        public IList<string> Hashtags { get; set; } = new List<string>();

        [JsonProperty(PropertyName = "eTag")]
        public string ETag { get; set; } = Guid.NewGuid().ToString();
    }
}