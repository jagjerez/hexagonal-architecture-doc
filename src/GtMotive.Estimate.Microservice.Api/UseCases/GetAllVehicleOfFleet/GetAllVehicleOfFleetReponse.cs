using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicleOfFleet
{
    public sealed class GetAllVehicleOfFleetReponse
    {
        public GetAllVehicleOfFleetReponse(
            Guid id,
            Model model,
            Brand brand,
            PlateCode plateCode,
            Year matriculateYear,
            DateTime factoryDate,
            FleetValue fleetCode)
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

        public GetAllVehicleOfFleetReponse(
            Guid id,
            string model,
            string brand,
            string plateCode,
            int matriculateYear,
            DateTime factoryDate,
            string fleetCode)
        {
            Id = id;
            Model = model;
            Brand = brand;
            PlateCode = plateCode;
            MatriculateYear = matriculateYear;
            FleetCode = fleetCode;

            FactoryDate = factoryDate;
        }

        private GetAllVehicleOfFleetReponse()
        {
        }

        public Guid Id { get; private set; }

        public string Model { get; private set; }

        public string Brand { get; private set; }

        public string PlateCode { get; private set; }

        public int MatriculateYear { get; private set; }

        public DateTime FactoryDate { get; private set; }

        public string FleetCode { get; private set; }
    }
}
