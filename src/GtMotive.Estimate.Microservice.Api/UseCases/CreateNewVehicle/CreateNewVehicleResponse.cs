using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle
{
    public sealed class CreateNewVehicleResponse
    {
        public CreateNewVehicleResponse(
            Model model,
            Brand brand,
            PlateCode plateCode,
            Year matriculateYear,
            FleetValue fleetCode,
            DateTime factoryDate,
            Guid id)
        {
            Id = id;
            if (model != null)
            {
                Model = model.Value;
            }

            if (brand != null)
            {
                Brand = brand.Value;
            }

            if (plateCode != null)
            {
                PlateCode = plateCode.Value;
            }

            if (matriculateYear != null)
            {
                MatriculateYear = matriculateYear.Value;
            }

            if (fleetCode != null)
            {
                FleetCode = fleetCode.Value;
            }

            FactoryDate = factoryDate;
        }

        public CreateNewVehicleResponse(
            string model,
            string brand,
            string plateCode,
            int matriculateYear,
            string fleetCode,
            DateTime factoryDate,
            Guid id)
        {
            Id = id;
            Model = model;
            Brand = brand;
            PlateCode = plateCode;
            MatriculateYear = matriculateYear;
            FleetCode = fleetCode;
            FactoryDate = factoryDate;
        }

        private CreateNewVehicleResponse()
        {
        }

        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string Model { get; private set; }

        [Required]
        public string Brand { get; private set; }

        [Required]
        public string PlateCode { get; private set; }

        [Required]
        public int MatriculateYear { get; private set; }

        [Required]
        public DateTime FactoryDate { get; private set; }

        [Required]
        public string FleetCode { get; private set; }
    }
}
