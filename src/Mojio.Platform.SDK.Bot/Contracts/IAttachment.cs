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

namespace Mojio.Platform.SDK.Bot.Contracts
{
    public interface IAttachment
    {
        string ContentType { get; set; }
        string ContentUrl { get; set; }
        object Content { get; set; }
        string FallbackText { get; set; }
        string Title { get; set; }
        string TitleLink { get; set; }
        string Text { get; set; }
        string ThumbnailUrl { get; set; }
    }
}