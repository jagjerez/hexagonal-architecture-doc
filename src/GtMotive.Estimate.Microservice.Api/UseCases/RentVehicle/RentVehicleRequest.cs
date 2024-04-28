using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleRequest"/> class.
        /// </summary>
        /// <param name="vehicleId">Represent vehicle id relation.</param>
        /// <param name="customerIdentity">Represent customer id relation.</param>
        /// <param name="startDate">Represent the start date of the rental.</param>
        public RentVehicleRequest(
            Guid vehicleId,
            string customerIdentity,
            DateTime startDate)
        {
            VehicleId = vehicleId;
            CustomerIdentity = customerIdentity;

            StartDate = startDate;
        }

        private RentVehicleRequest()
        {
        }

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
