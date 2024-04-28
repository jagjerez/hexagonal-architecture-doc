using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Entities
{
    /// <summary>
    /// Represent a renting of vehicle.
    /// </summary>
    public interface IRenting
    {
        /// <summary>
        /// Gets represent unique identity for renting.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets represent vehicle id relation.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets represent customer id relation.
        /// </summary>
        public CustomerIdentity CustomerIdentity { get; }

        /// <summary>
        /// Gets represent the start date of the rental.
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// Gets represent the end date of the rental.
        /// </summary>
        public DateTime? EndDate { get; }
    }
}
