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
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Entities
{
    public class VinCommon : IVinCommon
    {
        public string Transmission { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Vin { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Cylinders { get; set; }
        public IMeasurement TotalFuelCapacity { get; set; }
        public string FuelType { get; set; }
        public double CityFuelEfficiency { get; set; }
        public double HighwayFuelEfficiency { get; set; }
        public double CombinedFuelEfficiency { get; set; }
        public bool Success { get; set; }
    }

    public class VinSummary : VinCommon, IVinSummary
    {
        public string Engine { get; set; }
    }

    public class VinDetails : VinCommon, IVinDetails
    {
        public string Market { get; set; }
        public string VehicleType { get; set; }
        public string BodyType { get; set; }
        public string DriveType { get; set; }
        public float FuelTankSize { get; set; }
        public ITransmission Transmission { get; set; }
        public IEngine EngineDetails { get; set; }
        public IList<IWarranty> Warranties { get; set; }
        public IList<IRecall> Recalls { get; set; }
        public IList<IServiceBulletin> ServiceBulletins { get; set; }
    }
}