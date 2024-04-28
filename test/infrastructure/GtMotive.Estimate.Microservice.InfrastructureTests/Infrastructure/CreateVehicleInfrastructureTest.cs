using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class CreateVehicleInfrastructureTest : InfrastructureTestBase
    {
        public CreateVehicleInfrastructureTest(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task CreateVehicleSuccess()
        {
            var model = "test1";
            var brand = "test1";
            var plateCode = "test2";
            var year = 2022;
            var fleetCode = "test";
            var factoryDate = DateTime.Now.AddYears(-3);
            var requestData = new CreateNewVehicleRequest(model, brand, plateCode, year, factoryDate, fleetCode);
            var uri = new Uri(Fixture.Server.BaseAddress, "/api/Vehicle/CreateNewVehicle");
            var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            using var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await Fixture.Server.CreateClient().PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var vehicleList = Newtonsoft.Json.JsonConvert.DeserializeObject<CreateNewVehicleResponse>(responseContent);
            Assert.NotNull(vehicleList);
        }
    }
}
