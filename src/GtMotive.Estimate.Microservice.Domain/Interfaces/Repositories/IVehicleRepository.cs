using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repository of vehicle.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Save data in database.
        /// </summary>
        /// <param name="vehicle">Entity data.</param>
        /// <returns>Create etntity.</returns>
        Task Add(IVehicle vehicle);

        /// <summary>
        /// Get all vehicle by code fleet.
        /// </summary>
        /// <param name="fleetCode">Represent fleet code.</param>
        /// <returns>Get collection of vehicles in domain format.</returns>
        Task<CollectionVehicle> GetAllVehicleByFleetCode(FleetValue fleetCode);

        /// <summary>
        /// Get vehicle by id.
        /// </summary>
        /// <param name="vehicleId">Represent vehicleId.</param>
        /// <returns>Get IVehicle entity.</returns>
        Task<IVehicle> GetById(Guid vehicleId);
    }
}
