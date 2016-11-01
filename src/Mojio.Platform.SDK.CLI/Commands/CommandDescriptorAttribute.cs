using System;

namespace Mojio.Platform.SDK.CLI.Commands
{
    public class CommandDescriptorAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
    }
}