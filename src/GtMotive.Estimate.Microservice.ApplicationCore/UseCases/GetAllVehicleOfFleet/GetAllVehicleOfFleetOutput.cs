using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet
{
    /// <summary>
    /// Output get all vehicle message.
    /// </summary>
    public sealed class GetAllVehicleOfFleetOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehicleOfFleetOutput"/> class.
        /// </summary>
        /// <param name="vehicles">all vehicles.</param>
        public GetAllVehicleOfFleetOutput(IEnumerable<IVehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        private GetAllVehicleOfFleetOutput()
        {
        }

        /// <summary>
        /// Gets all vehicles.
        /// </summary>
        public IEnumerable<IVehicle> Vehicles { get; private set; }
    }
}
