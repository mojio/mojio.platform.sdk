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
using Mojio.Platform.SDK.Contracts.Machine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Simulation
{
    public class SavedMachineStatesProvider
    {
        private readonly ISerializer _serializer;

        public SavedMachineStatesProvider(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public async Task<List<IMachineStates>> GetExportedStates(string root = null, string searchPattern = "*.json")
        {
            var list = new List<IMachineStates>();
            if (string.IsNullOrEmpty(searchPattern)) searchPattern = "*.json";

            if (string.IsNullOrEmpty(root))
            {
                root = typeof(SavedMachineStatesProvider).GetTypeInfo().Assembly.CodeBase;
                var baseUri = new Uri(root, UriKind.RelativeOrAbsolute);
                var fileInfo = new FileInfo(baseUri.LocalPath);
                root = fileInfo.Directory.FullName;
                if (Directory.Exists(Path.Combine(root, "Machine")))
                {
                    root = Path.Combine(root, "Machine");
                }
            }
            if (string.IsNullOrEmpty(root)) return null;
            if (!Directory.Exists(root)) return null;

            var files = Directory.GetFiles(root, searchPattern);
            foreach (var f in files)
            {
                try
                {
                    var e = _serializer.Deserialize<IMachineStates>(File.ReadAllText(f));
                    if (e != null) list.Add(e);
                }
                catch (Exception e)
                {
                }
            }

            return list;
        }
    }
}