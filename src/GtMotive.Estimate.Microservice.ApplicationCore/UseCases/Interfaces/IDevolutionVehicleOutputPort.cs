using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces
{
    /// <summary>
    /// Interface to define devolution vehicle output port.
    /// </summary>
    public interface IDevolutionVehicleOutputPort : IOutputPortStandard<DevolutionVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Informs the vehicle has not been returned.
        /// </summary>
        /// <param name="message">Text description.</param>
        void VehicleNoReturnedHandle(string message);
    }
}
