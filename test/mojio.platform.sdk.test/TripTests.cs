using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Machine;
using Mojio.Platform.SDK.Entities.Machine;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class TripTests
    {
        private readonly IClient _client;

        private ITrip Trip { get; set; }
        private IMojio Mojio { get; set; }
        private IVehicle Vehicle { get; set; }

        public TripTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
        }

        private async Task<ITrip> GetTrip()
        {
            if (Trip != null)
                return Trip;

            var trips = await _client.Trips();
            var trip = trips.Response.Data.First();

            Trip = trip;
            return trip;
        }

        private async Task<IMojio> GetMojio()
        {
            if (Mojio != null)
                return Mojio;

            var mojios = await _client.Mojios();
            var mojio = mojios.Response.Data.First();

            Mojio = mojio;
            return mojio;
        }

        private async Task<IVehicle> GetVehicle()
        {
            if (Vehicle != null)
                return Vehicle;

            var vehicles = await _client.Vehicles();
            var vehicle = vehicles.Response.Data.First();

            Vehicle = vehicle;
            return vehicle;
        }

        private async Task<IPlatformResponse<string>> SimulateTripAsync()
        {
            IVehicle vehicle = await GetVehicle();
            IMojio mojio = await GetMojio();

            var machineRequest = new MachineRequest
            {
                IMEI = mojio.IMEI,
                Vehicle = vehicle,
                TelematicDevice = mojio
            };

            var simulate = await _client.Simulate(machineRequest);
            return simulate;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetTripWithTripIdTestAsync()
        {
            var trip = await GetTrip();

            var tripResponse = await _client.GetTrip(trip.Id);
            Assert.NotNull(tripResponse.Response);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetTripsTestAsync()
        {
            var tripsResponse = await _client.Trips();
            var trips = tripsResponse.Response.Data;

            Assert.NotNull(trips);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task UpdateTripNameTestAsync()
        {
            var trip = await GetTrip();
            Guid g = new Guid();

            var updateNameResponse = await _client.UpdateTripName(trip.Id, g.ToString());

            Assert.True(updateNameResponse.Success);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task TripHistoryLocationsTestAsync()
        {
            var trip = await GetTrip();

            var tripLocations = await _client.TripHistoryLocations(trip.Id);
            Assert.NotNull(tripLocations.Response.Data);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task TripHistoryStatesTestAsync()
        {
            var trip = await GetTrip();

            var tripHistory = await _client.TripHistoryLocations(trip.Id);
            Assert.NotNull(tripHistory.Response.Data);
        }


        //TODO: Fix the simulate trip method, then simulate a trip before deleting it
        /*
        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task DeleteTripWithTripIdTestAsync()
        {
            Assert.True(true);
        }
        */

    }
}
