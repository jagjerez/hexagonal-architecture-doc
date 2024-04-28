using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Factories
{
    /// <summary>
    /// Represent renting factory.
    /// </summary>
    public interface IRentingFactory
    {
        /// <summary>
        /// Represent new instance of renting.
        /// </summary>
        /// <param name="vehicleId">represent vehicle id relation.</param>
        /// <param name="customerIdentity">represent customer id relation.</param>
        /// <param name="startDate">represent the start date of the rental.</param>
        /// <param name="endDate">represent the end date of the rental.</param>
        /// <returns>Return new instance of renting.</returns>
        IRenting NewRenting(
            Guid vehicleId,
            CustomerIdentity customerIdentity,
            DateTime startDate,
            DateTime? endDate);
    }
}
