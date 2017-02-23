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
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "get-apps", Description = "List out all apps", Usage = "get-apps")]
    public class GetAppsCommand : BaseCommand
    {
        public override async Task Execute()
        {
            await Authorize();

            var result = await SimpleClient.Apps();
            Log.Debug(result);

            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "delete-app", Description = "Delete an app", Usage = "delete-apps /id:appid")]
    public class DeleteAppCommand : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        public override async Task Execute()
        {
            await Authorize();
            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var result = await SimpleClient.DeleteApp(g);
                Log.Debug(result);
            }
            else
            {
                Log.Debug("Invalid app id specified");
            }
            UpdateAuthorization();
        }
    }

    [CommandDescriptor(Name = "update-app", Description = "Update an app", Usage = "update-app /id:appid /image:<path to image> /n:newname /r:http://localhost /r:https://ww.moj.io /d:'this is your app description'")]
    public class AppCommands : BaseCommand
    {
        [Argument(ArgumentType.Required, ShortName = "id")]
        public string Id { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "n")]
        public string Name { get; set; }

        [Argument(ArgumentType.Multiple, ShortName = "r")]
        public string[] RedirectUris { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "d")]
        public string Description { get; set; }

        [Argument(ArgumentType.AtMostOnce, ShortName = "i")]
        public string Image { get; set; }

        public override async Task Execute()
        {
            await Authorize();

            if (string.IsNullOrEmpty(Id)) return;
            Guid g;
            if (Guid.TryParse(Id, out g))
            {
                var apps = await SimpleClient.Apps();
                var app = (from a in apps.Response.Data where a.Id == g select a).FirstOrDefault();
                if (app == null)
                {
                    Log.Debug("Could not find app with the id:{0}", g);
                    return;
                }
                var updateApp = false;
                if (!string.IsNullOrEmpty(Name))
                {
                    app.Name = Name;
                    updateApp = true;
                }
                if (!string.IsNullOrEmpty(Description))
                {
                    app.Description = Description;
                    updateApp = true;
                }
                if (RedirectUris != null && RedirectUris.Length > 0)
                {
                    app.RedirectUris = RedirectUris.ToList();
                    updateApp = true;
                }
                if (updateApp)
                {
                    var result = await SimpleClient.UpdateApp(app);
                    Log.Debug(result);
                }
                if (!string.IsNullOrEmpty(Image) && File.Exists(Image))
                {
                    Log.Debug("Updating app image");
                    var image = File.ReadAllBytes(Image);
                    var fi = new FileInfo(Image);
                    var imageResult = await SimpleClient.SaveImage(ImageEntities.Apps,  g, image, fi.Name, "image/" + fi.Extension);
                    Log.Debug(imageResult);

                    if (imageResult.Success)
                    {
                        var images = await SimpleClient.GetImage(ImageEntities.Apps, g);
                        Log.Debug(images);
                    }
                }
            }
            else
            {
                Log.Debug("Invalid app id specified");
            }
            UpdateAuthorization();
        }
    }
}