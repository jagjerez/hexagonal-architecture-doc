using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Factories
{
    /// <summary>
    /// Represent Fleet factory.
    /// </summary>
    public interface IFleetFactory
    {
        /// <summary>
        /// Create new instance of Fleet.
        /// </summary>
        /// <param name="fleetCode">Represents fleet code of real world.</param>
        /// <param name="vehicles">Represents all vehicles of fleet.</param>
        /// <returns>Return new instance of Fleet.</returns>
        IFleet NewFleetAggregate(FleetValue fleetCode, CollectionVehicle vehicles);
    }
}
