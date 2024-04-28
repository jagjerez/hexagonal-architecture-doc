using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represent vehicle entity of domain.
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="model">Param represent Model of vehicle.</param>
        /// <param name="brand">Param represent Brand of vehicle.</param>
        /// <param name="plateCode">Param represent PlateCode of vehicle.</param>
        /// <param name="matriculateYear">Param represent Matriculate Year of vehicle.</param>
        /// <param name="fleetCode">Param represent fleet code.</param>
        /// <param name="factoryDate">Param factory date.</param>
        /// <param name="id">Param represent Vehicle of vehicle.</param>
        protected Vehicle(
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

        private Vehicle()
        {
        }

        /// <summary>
        /// Gets or sets represent vehicle identity unique.
        /// </summary>
        public abstract Guid Id { get; protected set; }

        /// <summary>
        /// Gets or sets represent model of vehicle.
        /// </summary>
        public abstract Model Model { get; protected set; }

        /// <summary>
        /// Gets or sets represent brand of vehicle.
        /// </summary>
        public abstract Brand Brand { get; protected set; }

        /// <summary>
        /// Gets or sets represent plate code of vehicle.
        /// </summary>
        public abstract PlateCode PlateCode { get; protected set; }

        /// <summary>
        /// Gets or sets represent Matriculate year of vehicle.
        /// </summary>
        public abstract Year MatriculateYear { get; protected set; }

        /// <summary>
        /// Gets or sets represent factory date of vehicle.
        /// </summary>
        public abstract DateTime FactoryDate { get; protected set; }

        /// <summary>
        /// Gets or sets represent fleet code.
        /// </summary>
        public abstract FleetValue FleetCode { get; protected set; }

        /// <summary>
        /// Represent if a vehicle is enabled for use.
        /// </summary>
        /// <returns>value boolean.</returns>
        public bool IsEnabled()
        {
            var result = true;
            var dateNow = DateTime.Now;
            var diferenceInYear = dateNow.Year - FactoryDate.Year;
            if (dateNow.Month < FactoryDate.Month || (dateNow.Month == FactoryDate.Month && dateNow.Day < FactoryDate.Day))
            {
                diferenceInYear--;
            }

            if (diferenceInYear > 5)
            {
                result = false;
            }

            return result;
        }
    }
}
