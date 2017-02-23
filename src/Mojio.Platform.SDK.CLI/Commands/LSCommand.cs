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
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "ls", Description = "List out all .json files used for authentication", Usage = "ls")]
    public class LSCommand : BaseCommand
    {
        public override async Task Execute()
        {
            var files = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.json");
            foreach (var f in files)
            {
                Log.Debug((new FileInfo(f)).Name);
            }
            await TaskExtensions.CompletedTask;
        }
    }
}