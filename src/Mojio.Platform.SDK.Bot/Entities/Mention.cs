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

namespace Mojio.Platform.SDK.Bot.Entities
{
    public class Mention : IMention
    {
        [JsonProperty(PropertyName = "mentioned")]
        public IChannelAccount Mentioned { get; set; } = new ChannelAccount();

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}