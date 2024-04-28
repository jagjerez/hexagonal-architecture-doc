using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle
{
    /// <summary>
    /// Input devolution vehicle.
    /// </summary>
    public sealed class DevolutionVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevolutionVehicleInput"/> class.
        /// </summary>
        /// <param name="rentId">Rent Id.</param>
        public DevolutionVehicleInput(Guid rentId)
        {
            RentId = rentId;
        }

        private DevolutionVehicleInput()
        {
        }

        /// <summary>
        /// Gets Rent Id.
        /// </summary>
        public Guid RentId { get; private set; }
    }
}
