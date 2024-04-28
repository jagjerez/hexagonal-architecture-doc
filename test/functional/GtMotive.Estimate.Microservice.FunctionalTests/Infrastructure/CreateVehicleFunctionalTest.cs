using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    public class CreateVehicleFunctionalTest : FunctionalTestBase
    {
        public CreateVehicleFunctionalTest(CompositionRootTestFixture fixture)
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

            await Fixture.UsingHandlerForRequestResponse<CreateNewVehicleRequest, IWebApiPresenter>(async handler =>
            {
                // Arrange
                var request = new CreateNewVehicleRequest(model, brand, plateCode, year, factoryDate, fleetCode);

                // Act
                var response = await handler.Handle(request, CancellationToken.None);

                // Assert
                Assert.NotNull(response);
            });
        }
    }
}
