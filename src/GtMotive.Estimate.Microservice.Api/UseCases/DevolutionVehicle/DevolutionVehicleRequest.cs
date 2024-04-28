using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class DevolutionVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevolutionVehicleRequest"/> class.
        /// </summary>
        /// <param name="id">Id renting.</param>
        public DevolutionVehicleRequest(
            Guid id)
        {
            Id = id;
        }

        private DevolutionVehicleRequest()
        {
        }

        /// <summary>
        /// Gets represent id renting.
        /// </summary>
        public Guid Id { get; private set; }
    }
}
