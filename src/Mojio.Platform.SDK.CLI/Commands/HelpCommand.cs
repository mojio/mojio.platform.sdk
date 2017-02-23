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

using System.Threading.Tasks;
using TaskExtensions = Mojio.Platform.SDK.Contracts.Extension.TaskExtensions;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "help", Description = "This help", Usage = "help")]
    public class HelpCommand : BaseCommand
    {
        public override async Task Execute()
        {
            Log.Debug("\nMojio.Platform.SDK.CLI.exe command [args0...argsN]  Executes the command and exits immediately");
            Log.Debug("Mojio.Platform.SDK.CLI.exe filename  Executes the commands listed in the file, exists");
            Log.Debug("Mojio.Platform.SDK.CLI.exe starts the REPL");
            Log.Debug("");

            CommandFactory.DumpHelp();
            await TaskExtensions.CompletedTask;
        }
    }
}