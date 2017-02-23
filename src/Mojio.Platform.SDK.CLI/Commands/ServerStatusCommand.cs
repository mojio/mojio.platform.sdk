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
using System.IO;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Entities.DI;
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "status", Description = "Query the server for its status", Usage = "status")]
    public class ServerStatusCommand : BaseCommand
    {
        private readonly ISerialize _serialize;

        public ServerStatusCommand()
        {
            _serialize = DIContainer.Current.Resolve<ISerialize>();
        }
        public override async Task Execute()
        {
            var result = await SimpleClient.GetServerStatus();
            Log.Debug(result);

        }
    }
}