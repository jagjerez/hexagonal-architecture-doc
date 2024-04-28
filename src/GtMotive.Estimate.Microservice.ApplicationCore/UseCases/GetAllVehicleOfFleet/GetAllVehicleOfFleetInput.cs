using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet
{
    /// <summary>
    /// Input get all vehicle.
    /// </summary>
    public sealed class GetAllVehicleOfFleetInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehicleOfFleetInput"/> class.
        /// </summary>
        /// <param name="fleetCode">Fleet code.</param>
        public GetAllVehicleOfFleetInput(FleetValue fleetCode)
        {
            FleetCode = fleetCode;
        }

        private GetAllVehicleOfFleetInput()
        {
        }

        /// <summary>
        /// Gets Fleet code.
        /// </summary>
        public FleetValue FleetCode { get; private set; }
    }
}
