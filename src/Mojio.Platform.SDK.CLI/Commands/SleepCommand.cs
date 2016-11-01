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