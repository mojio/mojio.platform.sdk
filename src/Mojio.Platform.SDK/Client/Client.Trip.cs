using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {
        public async Task<IPlatformResponse<ITrip>> GetTrip(string tripId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<ITrip>(ApiEndpoint.Api, string.Format("v2/trips/{0}", tripId),
                    tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<ITrip>>(null);
        }

        public async Task<IPlatformResponse<IMessageResponse>> DeleteTrip(string tripId, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var result = await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, string.Format("v2/trips/{0}", tripId), tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);

                return result;
            }

            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }

        public async Task<IPlatformResponse<ITripsResponse>> Trips(int skip = 0, int top = 10, string filter = null, string select = null, string orderby = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                string path = $"v2/trips?{RandomQueryString()}";
                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";

                if (!string.IsNullOrEmpty(filter)) path = path + $"&filter={WebUtility.UrlEncode(filter)}";
                if (!string.IsNullOrEmpty(select)) path = path + $"&select={WebUtility.UrlEncode(select)}";
                if (!string.IsNullOrEmpty(orderby)) path = path + $"&orderby={WebUtility.UrlEncode(orderby)}";

                return await _clientBuilder.Request<ITripsResponse>(ApiEndpoint.Api, path, tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<ITripsResponse>>(null);
        }

        public async Task<IPlatformResponse<ITrip>> UpdateTripName(string tripId, string name, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<ITrip>(ApiEndpoint.Api, string.Format("v2/trips/{0}", tripId), tokenP.CancellationToken, tokenP.Progress, HttpMethod.Put, "{\"Name\": \"" + name + "\"}");
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<ITrip>>(null);
        }

        public async Task<IPlatformResponse<IVehicleLocationResponse>> TripHistoryLocations(string tripId, int skip = 0, int top = 10, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                string path = $"v2/trips/{tripId}/history/locations?{RandomQueryString()}";

                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";

                return await _clientBuilder.Request<IVehicleLocationResponse>(ApiEndpoint.Api, path,
                    tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVehicleLocationResponse>>(null);
        }

        public async Task<IPlatformResponse<IVehiclesResponse>> TripHistoryStates(string tripId, int skip = 0, int top = 10, string fields = null, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                string path = $"v2/trips/{tripId}/history/states?{RandomQueryString()}";

                if (skip > 0) path = path + $"&skip={skip}";
                if (top > 0) path = path + $"&top={top}";
                if (!string.IsNullOrEmpty(fields)) path = path + $"&fields={fields}";

                return await _clientBuilder.Request<IVehiclesResponse>(ApiEndpoint.Api, path, tokenP.CancellationToken,
                    tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IVehiclesResponse>>(null);
        }
    }
}