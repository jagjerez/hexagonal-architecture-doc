using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represent renting for customer of vehicle in domain layer.
    /// </summary>
    public abstract class Renting : IRenting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Renting"/> class.
        /// </summary>
        /// <param name="id">Represent unique identity for renting.</param>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        /// <param name="endDate">Represent the end date of the rental.</param>
        protected Renting(
            Guid id,
            Guid vehicleId,
            CustomerIdentity customerIdentity,
            DateTime startDate,
            DateTime? endDate)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerIdentity = customerIdentity;
            StartDate = startDate;
            EndDate = endDate;
        }

        private Renting()
        {
        }

        /// <summary>
        /// Gets or sets represent unique identity for renting.
        /// </summary>
        public abstract Guid Id { get; protected set; }

        /// <summary>
        /// Gets or sets represent vehicle id relation.
        /// </summary>
        public abstract Guid VehicleId { get; protected set; }

        /// <summary>
        /// Gets or sets represent customer id relation.
        /// </summary>
        public abstract CustomerIdentity CustomerIdentity { get; protected set; }

        /// <summary>
        /// Gets or sets represent the start date of the rental.
        /// </summary>
        public abstract DateTime StartDate { get; protected set; }

        /// <summary>
        /// Gets or sets represent the end date of the rental.
        /// </summary>
        public abstract DateTime? EndDate { get; protected set; }

        /// <summary>
        /// Setter end date of renting.
        /// </summary>
        /// <param name="endDate">End date of renting.</param>
        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}
