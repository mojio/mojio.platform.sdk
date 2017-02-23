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

using System.Collections.Generic;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Automation;
using Mojio.Platform.SDK.Entities.DI;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "automation", Description = "Run an automation profile", Usage = "automation /profile:ios")]
    public class AutomationCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "profile")]
        public string Profile { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "u")]
        public string Username { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "p")]
        public string Password { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "l")]
        public bool LoadTest { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var profile = DIContainer.Current.Resolve<IAutomationProfile>(Profile);
            if (profile != null)
            {
                var props = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(Username)) props.Add("username", Username);
                if (!string.IsNullOrEmpty(Password)) props.Add("password", Password);

                if(!LoadTest) props.Add("LoadTestProfile", "false");
                var logger = new ConsoleLogger(DIContainer.Current.Resolve<ISerializer>());
                await profile.Execute(logger, SimpleClient, props);

                Log.Debug(profile.Properties);
            }
            UpdateAuthorization();
        }
    }
}