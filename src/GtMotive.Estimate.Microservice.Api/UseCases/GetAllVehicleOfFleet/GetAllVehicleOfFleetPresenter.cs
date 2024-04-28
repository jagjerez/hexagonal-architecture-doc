using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicleOfFleet
{
    public sealed class GetAllVehicleOfFleetPresenter : IWebApiPresenter, IGetAllVehicleOfFleetOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void FleetNoHasVehiclesHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(GetAllVehicleOfFleetOutput response)
        {
            if (response != null)
            {
                var vehicles = new List<IVehicle>(response.Vehicles).Select(o => new GetAllVehicleOfFleetReponse(o.Id, o.Model, o.Brand, o.PlateCode, o.MatriculateYear, o.FactoryDate, o.FleetCode));
                ActionResult = new OkObjectResult(vehicles);
            }
        }
    }
}
