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

using Mojio.Platform.SDK.Contracts.Entities;
using System;

namespace Mojio.Platform.SDK.Entities
{
    public class Location : ILocation
    {
        public double Dilution { get; set; }
        public double Altitude { get; set; }
        public IAddress Address { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Status { get; set; }
        public string GeoHash { get; set; }
        public IMeasurement Accuracy { get; set; }
        public IHeading Heading { get; set; }
    }

    public class VirtualOdometer : Measurement, IVirtualodometer
    {
        public float RolloverValue { get; set; }
    }

    public class ConnectedState : IConnectedState {
        public DateTimeOffset Timestamp { get; set; }
        public bool Value { get; set; }
    }


}