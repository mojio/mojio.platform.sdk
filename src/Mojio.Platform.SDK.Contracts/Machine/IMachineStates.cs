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
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Contracts.Machine
{
    public interface IMachineStates
    {
        string Title { get; set; }
        int Duration { get; set; }
        IMinMax DurationLimit { get; set; }
        int NoOfVehicleStates { get; set; }
        IMinMax RPM { get; set; }
        IMinMax Speed { get; set; }
        IMinMax Fuel { get; set; }
        IMinMax FuelEfficiency { get; set; }
        IMinMax Battery { get; set; }
        IPoints Points { get; set; }
        bool CircularTrip { get; set; }
        IList<IVehicleState> VehicleStates { get; set; }
    }

    public interface IVehicleState
    {
        Guid MessageId { get; set; }
        IVehicle Vehicle { get; set; }
        IMachineTelematicDevice TelematicDevice { get; set; }
    }

    public interface IMinMax
    {
        int Min { get; set; }
        int Max { get; set; }
    }

    public interface IPoints
    {
        float[] Start { get; set; }
        float[] End { get; set; }
        float[] WayPoint { get; set; }
    }

    public interface IMachineTelematicDevice : IMojio
    {
    }
}