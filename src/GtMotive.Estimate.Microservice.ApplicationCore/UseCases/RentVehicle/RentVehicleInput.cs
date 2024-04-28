using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input for rent vehicle.
    /// </summary>
    public sealed class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        public RentVehicleInput(
            Guid vehicleId,
            string customerIdentity,
            DateTime startDate)
        {
            VehicleId = vehicleId;
            CustomerIdentity = new CustomerIdentity(customerIdentity);
            StartDate = startDate;
        }

        private RentVehicleInput()
        {
        }

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
