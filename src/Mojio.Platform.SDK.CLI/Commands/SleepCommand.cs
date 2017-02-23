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

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "sleep", Description = "For automation purposes, sleep the call X number of milliseconds", Usage = "sleep /t:1000")]
    public class SleepCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "t", DefaultValue = 1000)]
        public int Time { get; set; }

        public override async Task Execute()
        {
            await Task.Delay(Time);
        }
    }
}