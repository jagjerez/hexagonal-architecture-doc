using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle
{
    public sealed class CreateNewVehiclePresenter : IWebApiPresenter, ICreateNewVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(CreateNewVehicleOutput response)
        {
            if (response != null)
            {
                var responseData = new CreateNewVehicleResponse(response.Model, response.Brand, response.PlateCode, response.MatriculateYear, response.FleetCode, response.FactoryDate, response.Id);
                ActionResult = new OkObjectResult(responseData);
            }
        }

        public void VehicleNoCanCreateHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }
    }
}
