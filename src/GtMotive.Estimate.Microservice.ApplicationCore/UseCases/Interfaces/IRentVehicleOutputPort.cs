using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces
{
    /// <summary>
    /// Interface to define rent vehicle output port.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Informs the renting has not been created.
        /// </summary>
        /// <param name="message">Text description.</param>
        void RentingNoCreatedHandle(string message);
    }
}
