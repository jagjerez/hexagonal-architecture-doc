using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output for rent vehicle.
    /// </summary>
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">Represent unique identity for renting.</param>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        public RentVehicleOutput(
            Guid id,
            Guid vehicleId,
            CustomerIdentity customerIdentity,
            DateTime startDate)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerIdentity = customerIdentity;
            StartDate = startDate;
        }

        private RentVehicleOutput()
        {
        }

        /// <summary>
        /// Gets represent unique identity for renting.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets represent vehicle id relation.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Gets represent customer id relation.
        /// </summary>
        public CustomerIdentity CustomerIdentity { get; private set; }

        /// <summary>
        /// Gets represent the start date of the rental.
        /// </summary>
        public DateTime StartDate { get; private set; }
    }
}
