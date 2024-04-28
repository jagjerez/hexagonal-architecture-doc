using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces
{
    /// <summary>
    /// Interface to define the create new vehicle output port.
    /// </summary>
    public interface ICreateNewVehicleOutputPort : IOutputPortStandard<CreateNewVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Informs the resource has been created.
        /// </summary>
        /// <param name="message">Text description.</param>
        void VehicleNoCanCreateHandle(string message);
    }
}
