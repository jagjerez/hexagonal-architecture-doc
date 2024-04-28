using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Factories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Services;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.Utils;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class CreateVehicleUnitTest
    {
        [Fact]
        public async Task CreateVehicleSuccess()
        {
            var fleetCode = new FleetValue("test");
            IVehicleFactory vehicleFactory = new EntityFactory();
            IFleetFactory fleetFactory = new EntityFactory();
            var vehicleToSave = vehicleFactory.NewVehicle(
                    new Model("test1"),
                    new Brand("test1"),
                    new PlateCode("test2"),
                    new Year(2022),
                    DateTime.Now.AddYears(-3),
                    fleetCode);
            var vehicleDefault = vehicleFactory.NewVehicle(
                    new Model("test1"),
                    new Brand("test1"),
                    new PlateCode("test1"),
                    new Year(2022),
                    DateTime.Now.AddYears(-3),
                    fleetCode);
            var collectionVehicle = new CollectionVehicle();
            collectionVehicle.Add(vehicleDefault);
            var mockIVehicleRepository = new Mock<IVehicleRepository>();
            mockIVehicleRepository.Setup(r => r.GetAllVehicleByFleetCode(fleetCode)).Returns(Task.FromResult(collectionVehicle));
            var fleetService = new FleetServices(fleetFactory, mockIVehicleRepository.Object);
            try
            {
                await fleetService.CreateVehicle(vehicleToSave);
                Assert.True(true);
            }
            catch (DomainException)
            {
                Assert.True(false);
            }
        }
    }
}
