using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Entities;
using Mojio.Platform.SDK.SimpleClient;
using Mojio.Platform.SDK.Tests;
using Xunit;

namespace mojio.platform.sdk.test
{
    public class VehicleTests
    {
        private readonly IClient _client;

        private IVehicle Vehicle { get; set; }

        public VehicleTests()
        {
            var credentials = Mother.Credentials;

            _client = Mother.GetNewSimpleClient;
            _client.Login(credentials.Item1, credentials.Item3);
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

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehiclesTestAsync()
        {
            var vehicles = await _client.Vehicles();
            Assert.NotNull(vehicles.Response.Data);
        }
        
        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicleHistoryStatesTestAsync()
        {
            var vehicle = await GetVehicle();
            
            var vehicleHistory = await _client.VehicleHistoryStates(vehicle.Id);
            Assert.NotNull(vehicleHistory.Response.Data);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicleVinLookupTestAsync()
        {
            var vehicle = await GetVehicle();

            var vinLookup = await _client.VehicleVinLookup(vehicle.Id);
            Assert.NotNull(vinLookup.Response);
        }

        
        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicleNextServiceTestAsync()
        {
            var vehicle = await GetVehicle();

            var nextService = await _client.VehicleNextService(vehicle.Id);
            Assert.NotNull(nextService.Response);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicleTripsTestAsync()
        {
            var vehicle = await GetVehicle();

            var vehicleTrips = await _client.VehicleTrips(vehicle.Id);
            Assert.NotNull(vehicleTrips.Response.Data);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicleLocationsTestAsync()
        {
            var vehicle = await GetVehicle();

            var vehicleLocations = await _client.VehicleLocations(vehicle.Id);
            Assert.NotNull(vehicleLocations);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task CreateVehicleTestAsync()
        {
            IVehicle vehicle = new Vehicle();

            var response = await _client.CreateNewVehicle(vehicle);
            Assert.True(response.Success);
        }
        
    }
}
