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
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-user", Description = "Gets the specified user", Usage = "get-user  /i:<user-id>")]
    public class GetUserCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();
            var g = Guid.Empty;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.GetUser(g);
                Log.Debug(result);
                UpdateAuthorization();
            }
            else
            {
                Log.Info("Invalid Id specified.");
            }
        }
    }
    [CommandDescriptor(Name = "get-users", Description = "Gets the specified user", Usage = "get-users")]
    public class GetUsersCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "t")]
        public int Top { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public int Skip { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "f")]
        public string Filter { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "se")]
        public string Select { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "order")]
        public string OrderBy { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.Users(Skip, Top, Filter, Select, OrderBy);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }
}
