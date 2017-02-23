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

using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Mojio.Platform.SDK.CLI.Commands
{
    public class CommandFactory
    {
        private static readonly Dictionary<string, Tuple<CommandDescriptorAttribute, Type>> Commands = new Dictionary<string, Tuple<CommandDescriptorAttribute, Type>>();
        private static ILog Log;
        private readonly ISerializer _serializer;

        static CommandFactory()
        {
            var commandTypes = from t in typeof(CommandFactory).GetTypeInfo().Assembly.GetTypes()
                               where
                                t.GetTypeInfo().IsClass
                                && t.GetTypeInfo().IsPublic
                                && t.GetTypeInfo().IsSubclassOf(typeof(BaseCommand))
                               select t;
            foreach (var t in commandTypes)
            {
                foreach (var a in t.GetTypeInfo().GetCustomAttributes(typeof(CommandDescriptorAttribute), false))
                {
                    var d = a as CommandDescriptorAttribute;
                    if (d != null)
                    {
                        Commands.Add(d.Name.Trim().ToLowerInvariant(), new Tuple<CommandDescriptorAttribute, Type>(d, t));
                    }
                }
            }
        }

        public CommandFactory(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public static void DumpHelp()
        {
            if (Log == null) return;
            foreach (var c in Commands)
            {
                Log.Debug("\"{1}\" - {0}", c.Value.Item1.Description, c.Value.Item1.Usage);
            }
        }

        public ICommand GetCommand(string input, IClient client, ILog log)
        {
            Log = log;
            input = input.Trim();
            var lowerInput = input.ToLowerInvariant();
            if (string.IsNullOrEmpty(lowerInput)) return null;

            ICommand command = null;
            var key = "";
            foreach (var cmd in Commands)
            {
                if (input.StartsWith(cmd.Key))
                {
                    key = cmd.Key;
                    command = cmd.Value.Item2.GetTypeInfo().Assembly.CreateInstance(cmd.Value.Item2.FullName) as ICommand;
                    if (command == null) return null;
                }
            }
            if (command == null) return null;

            var args = input.Substring(key.Length).Trim().Split(' ');
            var finalArgs = new List<string>();
            var first = false;
            foreach (var a in args)
            {
                if (!string.IsNullOrEmpty(a))
                {
                    var arg = a;
                    if (!first && key.Contains(" "))
                    {
                        arg = "/i:" + arg;
                        first = true;
                    }
                    finalArgs.Add(arg);
                }
            }
            if (Parser.ParseArgumentsWithUsage(finalArgs.ToArray(), command))
            {
                command.SimpleClient = client as SimpleClient.SimpleClient;
                command.Log = log;

                //if (!string.IsNullOrEmpty(command.Out) && File.Exists(command.Out)) File.Delete(command.Out);
                if (!string.IsNullOrEmpty(command.Out))
                {
                    command.Log = new FileLogger(_serializer) { Outfile = command.Out };
                }
                else
                {
                    command.Log = log;
                }

                return command;
            }
            return null;
        }
    }
}