using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class RentVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleResponse"/> class.
        /// </summary>
        /// <param name="id">Represent unique identity for renting.</param>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        public RentVehicleResponse(
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

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleResponse"/> class.
        /// </summary>
        /// <param name="id">Represent unique identity for renting.</param>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        public RentVehicleResponse(
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

        private RentVehicleResponse()
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
