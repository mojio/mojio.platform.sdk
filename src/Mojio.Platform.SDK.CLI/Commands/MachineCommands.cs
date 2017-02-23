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

using Mojio.Platform.SDK.CLI.Simulation;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Machine;
using Mojio.Platform.SDK.Entities.DI;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "machine", Description = "Simulate a set of events", Usage = "machine /imei:<imei> /root:<json events root directory> /searchPattern:<*.json> /vin:<new vin>")]
    public class MachineCommands : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "i")]
        public string Imei { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "r")]
        public string Root { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "s")]
        public string SearchPattern { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "v")]
        public string Vin { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "t", DefaultValue = 0)]
        public int Time { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            var manager = new SavedMachineStatesProvider(DIContainer.Current.Resolve<ISerializer>());
            var machine = DIContainer.Current.Resolve<IMachine>();
            machine.Client = SimpleClient;
            var sims = await manager.GetExportedStates(Root, SearchPattern);

            foreach (var sim in sims)
            {
                var fileCount = 0;

                await machine.SendEvents(sim, Imei, Vin, Time);
            }

            UpdateAuthorization();
        }
    }
}