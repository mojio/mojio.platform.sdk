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

using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Bot.Entities;

namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface IMessage
    {
        SystemCommand? Type { get; set; }

        string Id { get; set; }
        string ConversationId { get; set; }
        DateTime? Created { get; set; }
        string SourceText { get; set; }
        string SourceLanguage { get; set; }
        string Language { get; set; }
        string Text { get; set; }
        IList<IAttachment> Attachments { get; set; }
        IChannelAccount From { get; set; }
        IChannelAccount To { get; set; }
        string ReplyToMessageId { get; set; }
        IList<IChannelAccount> Participants { get; set; }
        int? TotalParticipants { get; set; }
        IList<IMention> Mentions { get; set; }
        string Place { get; set; }
        string ChannelMessageId { get; set; }
        string ChannelConversationId { get; set; }
        object ChannelData { get; set; }
        object BotUserData { get; set; }
        IMojioConversationData BotConversationData { get; set; }
        object BotPerUserInConversationData { get; set; }
        ILocation Location { get; set; }
        IList<string> Hashtags { get; set; }
        string ETag { get; set; }
    }
}