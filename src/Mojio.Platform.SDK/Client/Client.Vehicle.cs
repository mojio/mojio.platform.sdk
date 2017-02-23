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
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public async Task<IPlatformResponse<IVehiclesResponse>> Vehicles(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);
            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                IPlatformResponse<IVehiclesResponse> vehicles = null;

                string path = $"v2/vehicles?{RandomQueryString()}";
                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";

                if (!string.IsNullOrEmpty(filter)) path = path + $"&filter={WebUtility.UrlEncode(filter)}";
                if (!string.IsNullOrEmpty(select)) path = path + $"&select={WebUtility.UrlEncode(select)}";
                if (!string.IsNullOrEmpty(orderby)) path = path + $"&orderby={WebUtility.UrlEncode(orderby)}";

                    vehicles = await _clientBuilder.Request<IVehiclesResponse>(ApiEndpoint.Api, path, tokenP.CancellationToken, tokenP.Progress);

                //if (vehicles != null && vehicles.Response != null && vehicles.Response.Data != null)
                //{
                //    var noImageVehicles = from v in vehicles.Response.Data where v.Image == null select v;
                //    if (noImageVehicles != null)
                //    {
                //        foreach (var v in noImageVehicles)
                //        {
                //            var result = await VehicleImage(v.Id, tokenP.CancellationToken, tokenP.Progress);
                //            if (result.Success && result.Response != null)
                //            {
                //                v.Image = result.Response;
                //            }
                //        }
                //    }
                //}

                return vehicles;
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVehiclesResponse>>(null);
        }

        public async Task<IPlatformResponse<IVinDetails>> VehicleVinLookup(Guid vehicleId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IVinDetails>(ApiEndpoint.Api,
                    string.Format("v2/vehicles/{0}/vin", vehicleId), tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVinDetails>>(null);
        }

        public async Task<IPlatformResponse<IVehiclesResponse>> VehicleHistoryStates(Guid vehicleId, int skip = 0, int top = 10, string fields = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                string path = $"v2/vehicles/{vehicleId}/history/states?{RandomQueryString()}";

                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";

                if (!string.IsNullOrEmpty(fields)) path = path + $"&fields={fields}";

                return await _clientBuilder.Request<IVehiclesResponse>(ApiEndpoint.Api, path, tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVehiclesResponse>>(null);
        }

        public async Task<IPlatformResponse<IServiceScheduleResponse>> VehicleNextService(Guid vehicleId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IServiceScheduleResponse>(ApiEndpoint.Api,
                    string.Format("v2/vehicles/{0}/serviceschedule/next", vehicleId), tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IServiceScheduleResponse>>(null);
        }

        public async Task<IPlatformResponse<ITripsResponse>> VehicleTrips(Guid vehicleId, int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                string path = $"v2/vehicles/{vehicleId}/trips?{RandomQueryString()}";
                path = path + $"&skip={skip}";
                path = path + $"&top={top}";

                if (!string.IsNullOrEmpty(filter)) path = path + $"&filter={WebUtility.UrlEncode(filter)}";
                if (!string.IsNullOrEmpty(select)) path = path + $"&select={WebUtility.UrlEncode(select)}";
                if (!string.IsNullOrEmpty(orderby)) path = path + $"&orderby={WebUtility.UrlEncode(orderby)}";

                return await _clientBuilder.Request<ITripsResponse>(ApiEndpoint.Api, path, tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<ITripsResponse>>(null);
        }

        public async Task<IPlatformResponse<IVehicleLocationResponse>> VehicleLocations(Guid vehicleId, int skip = 0, int top = 10, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                string path = $"v2/vehicles/{vehicleId}/history/locations?{RandomQueryString()}";

                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";

                return await _clientBuilder.Request<IVehicleLocationResponse>(ApiEndpoint.Api, path,
                    tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVehicleLocationResponse>>(null);
        }

        public async Task<IPlatformResponse<IVehicle>> CreateNewVehicle(IVehicle vehicle, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var json = _serializer.SerializeToString(vehicle);
                return await _clientBuilder.Request<IVehicle>(ApiEndpoint.Api, "v2/vehicles", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, json);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVehicle>>(null);
        }
    }
}