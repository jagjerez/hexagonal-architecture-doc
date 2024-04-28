using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle
{
    /// <summary>
    /// Output devolution vehicle.
    /// </summary>
    public sealed class DevolutionVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevolutionVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">Represent unique identity for renting.</param>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        /// <param name="endDate">Represent the end date of the rental.</param>
        public DevolutionVehicleOutput(
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

        private DevolutionVehicleOutput()
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

        /// <summary>
        /// Gets represent the end date of the rental.
        /// </summary>
        public DateTime? EndDate { get; private set; }
    }
}
