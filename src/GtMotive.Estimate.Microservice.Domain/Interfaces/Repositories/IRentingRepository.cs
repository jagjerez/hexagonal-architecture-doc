using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Renting repository.
    /// </summary>
    public interface IRentingRepository
    {
        /// <summary>
        /// Get renting by Id.
        /// </summary>
        /// <param name="id">Identity of renting.</param>
        /// <returns>Get renting instance.</returns>
        Task<IRenting> GetRentingById(Guid id);

        /// <summary>
        /// Get renting by customer.
        /// </summary>
        /// <param name="customerIdentity">Identity of customer.</param>
        /// <returns>Get renting instance.</returns>
        Task<IRenting> GetRentingByCustomerIdentity(CustomerIdentity customerIdentity);

        /// <summary>
        /// Get renting active for vehicle.
        /// </summary>
        /// <param name="vehicleId">Id of vehicle.</param>
        /// <returns>Get renting instance.</returns>
        Task<IRenting> GetRentingActiveForVehicle(Guid vehicleId);

        /// <summary>
        /// Add new renting.
        /// </summary>
        /// <param name="renting">Renting data.</param>
        /// <returns>async/await.</returns>
        Task Add(IRenting renting);

        /// <summary>
        /// Update renting.
        /// </summary>
        /// <param name="renting">Renting data.</param>
        /// <returns>async/await.</returns>
        Task Update(IRenting renting);
    }
}
