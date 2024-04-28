using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle
{
    /// <summary>
    /// Input create new vehicle message.
    /// </summary>
    public sealed class CreateNewVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewVehicleInput"/> class.
        /// </summary>
        /// <param name="model">Param represent Model of vehicle.</param>
        /// <param name="brand">Param represent Brand of vehicle.</param>
        /// <param name="plateCode">Param represent PlateCode of vehicle.</param>
        /// <param name="matriculateYear">Param represent Matriculate Year of vehicle.</param>
        /// <param name="factoryDate">Param represent factory date.</param>
        /// <param name="fleetCode">Param represent fleet code.</param>
        public CreateNewVehicleInput(
            string model,
            string brand,
            string plateCode,
            int matriculateYear,
            DateTime factoryDate,
            string fleetCode)
        {
            Model = new Model(model);
            Brand = new Brand(brand);
            PlateCode = new PlateCode(plateCode);
            MatriculateYear = new Year(matriculateYear);
            FactoryDate = factoryDate;
            FleetCode = new FleetValue(fleetCode);
        }

        private CreateNewVehicleInput()
        {
        }

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
