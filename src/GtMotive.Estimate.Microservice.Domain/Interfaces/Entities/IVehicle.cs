using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Entities
{
    /// <summary>
    /// Represent a vehicle contract.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Gets represent unique identity of vehicle.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets represent represent fleet code of real world.
        /// </summary>
        public FleetValue FleetCode { get; }

        /// <summary>
        /// Gets represent model of vehicle.
        /// </summary>
        public Model Model { get; }

        /// <summary>
        /// Gets represent brand of vehicle.
        /// </summary>
        public Brand Brand { get; }

        /// <summary>
        /// Gets represent plate code of vehicle.
        /// </summary>
        public PlateCode PlateCode { get; }

        /// <summary>
        /// Gets represent year of matriculated of vehicle.
        /// </summary>
        public Year MatriculateYear { get; }

        /// <summary>
        /// Gets represent fabrication of vehicle.
        /// </summary>
        public DateTime FactoryDate { get; }
    }
}
