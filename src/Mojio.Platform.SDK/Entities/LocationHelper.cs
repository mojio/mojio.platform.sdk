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
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio.Platform.SDK.Entities
{
    public class LocationHelper : ILocationHelper
    {
        private readonly IDIContainer _container;

        public LocationHelper(IDIContainer container)
        {
            _container = container;
        }

        public ILocation FindCenter(IList<ILocation> locations)
        {
            if (locations.Count == 1)
            {
                return locations.Single();
            }
            double x = 0, y = 0, z = 0;
            foreach (var geoCoordinate in locations)
            {
                if (geoCoordinate != null)
                {
                    var latitude = geoCoordinate.Lat * Math.PI / 180;
                    var longitude = geoCoordinate.Lng * Math.PI / 180;

                    x += Math.Cos(latitude) * Math.Cos(longitude);
                    y += Math.Cos(latitude) * Math.Sin(longitude);
                    z += Math.Sin(latitude);
                }
            }
            var total = locations.Count;
            x = x / total;
            y = y / total;
            z = z / total;
            var centralLongitude = Math.Atan2(y, x);
            var centralSquareRoot = Math.Sqrt(x * x + y * y);
            var centralLatitude = Math.Atan2(z, centralSquareRoot);

            var newLocation = _container.Resolve<ILocation>();
            newLocation.Lat = centralLatitude * 180 / Math.PI;
            newLocation.Lng = centralLongitude * 180 / Math.PI;
            return newLocation;
        }

        public double Distance(ILocation left, ILocation right, DistanceUnits units = DistanceUnits.Kilometers)
        {
            var theta = left.Lng - right.Lng;
            var dist = Math.Sin(deg2rad(left.Lat)) * Math.Sin(deg2rad(right.Lat)) + Math.Cos(deg2rad(left.Lat)) * Math.Cos(deg2rad(right.Lat)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (units == DistanceUnits.Kilometers)
            {
                dist = dist * 1.609344;
            }
            else if (units == DistanceUnits.NauticalMiles)
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        public double ZoomToAspect(int zoomLevel)
        {
            return 591657550.500000 / Math.Pow(2, zoomLevel - 1);
        }

        public double ZoomToLocationBounds(ILocation left, ILocation right)
        {
            var distance = Distance(left, right, DistanceUnits.Kilometers);
            var zoom = 30;
            while (zoom > 0)
            {
                var aspect = ZoomToAspect(zoom);
                if (aspect > distance)
                {
                    zoom--;
                }
                else
                {
                    break;
                }
            }
            return 0;
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}