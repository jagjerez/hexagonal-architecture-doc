using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Factories
{
    /// <summary>
    /// Represent vehicle factory.
    /// </summary>
    public interface IVehicleFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="model">Model code.</param>
        /// <param name="brand">Brand code.</param>
        /// <param name="plateCode">Plate code.</param>
        /// <param name="matriculateYear">Matriculate year.</param>
        /// <param name="factoryDate">Factory date.</param>
        /// <param name="fleetCode">Fleet code.</param>
        /// <returns>Vehicle instance.</returns>
        IVehicle NewVehicle(
            Model model,
            Brand brand,
            PlateCode plateCode,
            Year matriculateYear,
            DateTime factoryDate,
            FleetValue fleetCode);
    }
}
