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

using System.Linq;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.CLI.Commands
{
    [CommandDescriptor(Name = "where is", Description = "Provide a url to the car specified", Usage = "where is <vehicle name>")]
    public class LocationCommand : BaseCommand
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "i")]
        public string Input { get; set; }

        public override async Task Execute()
        {
            await Authorize();
            var vehicleName = Input.ToLowerInvariant().Trim();
            if (vehicleName.EndsWith("?")) vehicleName = vehicleName.Substring(0, vehicleName.Length - 1);
            var vehicles = await SimpleClient.Vehicles();
            if (!vehicles.Success)
            {
                Log.Debug("Failed to retrieve vehicles.");
            }
            else
            {
                var v = (from x in vehicles.Response.Data where x.Name.ToLowerInvariant().Contains(vehicleName) select x).FirstOrDefault();
                if (v != null)
                {
                    Log.Debug("It is near {2}, map: http://maps.google.com/maps?&z=10&q={0}+{1}&ll={0}+{1}", v.Location.Lat, v.Location.Lng, v.Location.Address.FormattedAddress);
                }
            }
            UpdateAuthorization();
        }
    }
}