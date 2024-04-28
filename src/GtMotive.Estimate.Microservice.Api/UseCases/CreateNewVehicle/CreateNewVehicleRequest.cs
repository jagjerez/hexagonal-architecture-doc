using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle
{
    public sealed class CreateNewVehicleRequest : IRequest<IWebApiPresenter>
    {
        public CreateNewVehicleRequest(
            string model,
            string brand,
            string plateCode,
            int matriculateYear,
            DateTime factoryDate,
            string fleetCode)
        {
            Model = model;
            Brand = brand;
            PlateCode = plateCode;
            MatriculateYear = matriculateYear;
            FleetCode = fleetCode;
            FactoryDate = factoryDate;
        }

        private CreateNewVehicleRequest()
        {
        }

        public string Model { get; private set; }

        public string Brand { get; private set; }

        public string PlateCode { get; private set; }

        public int MatriculateYear { get; private set; }

        public DateTime FactoryDate { get; private set; }

        public string FleetCode { get; private set; }
    }
}
