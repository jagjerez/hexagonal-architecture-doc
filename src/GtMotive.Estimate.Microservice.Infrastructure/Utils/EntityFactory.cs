using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Factories;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Utils
{
    public class EntityFactory : IVehicleFactory, IRentingFactory, IFleetFactory
    {
        public IFleet NewFleetAggregate(FleetValue fleetCode, CollectionVehicle vehicles) => new Fleet(fleetCode, vehicles);

        public IRenting NewRenting(Guid vehicleId, CustomerIdentity customerIdentity, DateTime startDate, DateTime? endDate) =>
            new RentingEntity(vehicleId, customerIdentity, startDate, endDate);

        public IVehicle NewVehicle(Model model, Brand brand, PlateCode plateCode, Year matriculateYear, DateTime factoryDate, FleetValue fleetCode) =>
            new VehicleEntity(model, brand, plateCode, matriculateYear, factoryDate, fleetCode);
    }
}
