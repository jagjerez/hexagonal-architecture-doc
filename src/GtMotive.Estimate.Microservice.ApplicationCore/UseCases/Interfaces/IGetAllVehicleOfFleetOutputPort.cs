using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces
{
    /// <summary>
    /// Interface to define get all vehicle output port.
    /// </summary>
    public interface IGetAllVehicleOfFleetOutputPort : IOutputPortStandard<GetAllVehicleOfFleetOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Informs the fleets of vehicles.
        /// </summary>
        /// <param name="message">Text description.</param>
        void FleetNoHasVehiclesHandle(string message);
    }
}
