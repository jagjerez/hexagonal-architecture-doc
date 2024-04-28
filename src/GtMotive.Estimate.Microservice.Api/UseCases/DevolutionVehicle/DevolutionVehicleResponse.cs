using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class DevolutionVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevolutionVehicleResponse"/> class.
        /// </summary>
        /// <param name="id">Represent unique identity for renting.</param>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        public DevolutionVehicleResponse(
            Guid id,
            Guid vehicleId,
            CustomerIdentity customerIdentity,
            DateTime startDate)
        {
            Id = id;
            VehicleId = vehicleId;
            if (customerIdentity != null)
            {
                CustomerIdentity = customerIdentity.Value;
            }

            StartDate = startDate;
        }

        public DevolutionVehicleResponse(
            Guid id,
            Guid vehicleId,
            string customerIdentity,
            DateTime startDate)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerIdentity = customerIdentity;

            StartDate = startDate;
        }

        private DevolutionVehicleResponse()
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
        public string CustomerIdentity { get; private set; }

        /// <summary>
        /// Gets represent the start date of the rental.
        /// </summary>
        public DateTime StartDate { get; private set; }
    }
}
