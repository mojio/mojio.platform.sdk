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
    [CommandDescriptor(Name = "rename-mojio", Description = "Rename a mojio", Usage = "rename-mojio /id:<mojio id> /name:<mojio name>")]
    public class RenameMojioCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        [Argument(ArgumentType.Required, ShortName = "n")]
        public string Name { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var g = Guid.Empty;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.RenameMojio(g, Name);
                Log.Debug(result);
                UpdateAuthorization();
            }
            else
            {
                Log.Info("Invalid Id specified.");
            }
        }
    }

    [CommandDescriptor(Name = "get-mojios", Description = "List out all mojios", Usage = "get-mojios")]
    public class GetMojiosCommand : BaseCommand
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

            var result = await SimpleClient.Mojios(Skip, Top, Filter, Select, OrderBy);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "claim-mojio", Description = "Claim a mojio", Usage = "claim-mojio /imei:99991234567890987")]
    public class MojioCommands : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Imei { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.ClaimMojio(Imei);
            Log.Debug(result);
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "delete-mojio", Description = "Delete a mojio", Usage = "delete-mojio /id:<mojio-id>")]
    public class DeleteMojioCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var g = Guid.Empty;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.DeleteMojio(g);
                Log.Debug(result);
                UpdateAuthorization();
            }
            else
            {
                Log.Info("Invalid Id specified.");
            }
        }
    }

}