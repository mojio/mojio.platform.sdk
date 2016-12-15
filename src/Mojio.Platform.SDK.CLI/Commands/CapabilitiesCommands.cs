using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-capabilities", Description = "Get the capabilities for a mojio",
         Usage = "get-capabilities")]
    public class CapabilitiesCommands : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.Capabilities(g);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid mojio id specified");
            }

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "update-wifi", Description = "Update the wifi settings for a specific device",
         Usage = "udpate-wifi")]
    public class UpdateWifiCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "ssid")]
        public string SSID { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "password")]
        public string Password { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "radiostatus")]
        public WifiRadioStatus? RadioStatus { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "timetolive")]
        public TimeSpan? TimeToLive { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.UpdateWifiSettings(g, SSID, Password, RadioStatus, TimeToLive);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid mojio id specified");
            }

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "get-updated-wifi-settings", Description = "Get Wifi settings after you send an update.",
         Usage = "get-updated-wifi-settings")]
    public class GetWifiSettingsAfterUpdateCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.Required, ShortName = "transactionid")]
        public string TransactionId { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            Guid m;
            if (Guid.TryParse(Id, out m))
            {
                Guid t;
                if (Guid.TryParse(TransactionId, out t))
                {
                    var result = await SimpleClient.GetWifiSettingsAfterUpdate(m, t);
                    Log.Debug(result);
                }
                else
                {
                    Log.Debug("Invalid transaction id specified");
                }
            }
            else
            {
                Log.Debug("Invalid mojio id specified");
            }

            UpdateAuthorization();
        }
    }
}

//f38ba225-a6c3-4b8d-84af-f7d0cce8a35b