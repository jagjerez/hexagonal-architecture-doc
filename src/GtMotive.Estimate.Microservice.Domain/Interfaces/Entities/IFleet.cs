using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Entities
{
    /// <summary>
    /// Represent contract of fleet entity.
    /// </summary>
    public interface IFleet
    {
        /// <summary>
        /// Gets represent fleet code.
        /// </summary>
        public FleetValue FleetCode { get; }

        /// <summary>
        /// Gets represent all vehicles of fleets.
        /// </summary>
        public CollectionVehicle Vehicles { get; }
    }
}
