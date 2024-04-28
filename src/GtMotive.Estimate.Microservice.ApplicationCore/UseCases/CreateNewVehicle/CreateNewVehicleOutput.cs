using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle
{
    /// <summary>
    /// Output create new vehicle message.
    /// </summary>
    public sealed class CreateNewVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewVehicleOutput"/> class.
        /// </summary>
        /// <param name="model">Param represent Model of vehicle.</param>
        /// <param name="brand">Param represent Brand of vehicle.</param>
        /// <param name="plateCode">Param represent PlateCode of vehicle.</param>
        /// <param name="matriculateYear">Param represent Matriculate Year of vehicle.</param>
        /// <param name="fleetCode">Param represent fleet code.</param>
        /// <param name="factoryDate">Param represent factory date.</param>
        /// <param name="id">Param represent Vehicle of vehicle.</param>
        public CreateNewVehicleOutput(
            Model model,
            Brand brand,
            PlateCode plateCode,
            Year matriculateYear,
            FleetValue fleetCode,
            DateTime factoryDate,
            Guid id)
        {
            Id = id;
            FactoryDate = factoryDate;
            Model = model;
            Brand = brand;
            PlateCode = plateCode;
            MatriculateYear = matriculateYear;
            FleetCode = fleetCode;
        }

        private CreateNewVehicleOutput()
        {
        }

        /// <summary>
        /// Gets represent vehicle identity unique.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets represent model of vehicle.
        /// </summary>
        public Model Model { get; private set; }

        /// <summary>
        /// Gets represent brand of vehicle.
        /// </summary>
        public Brand Brand { get; private set; }

        /// <summary>
        /// Gets represent plate code of vehicle.
        /// </summary>
        public PlateCode PlateCode { get; private set; }

        /// <summary>
        /// Gets represent Matriculate year of vehicle.
        /// </summary>
        public Year MatriculateYear { get; private set; }

        /// <summary>
        /// Gets represent factory date of vehicle.
        /// </summary>
        public DateTime FactoryDate { get; private set; }

        /// <summary>
        /// Gets represent fleet code.
        /// </summary>
        public FleetValue FleetCode { get; private set; }
    }
}
