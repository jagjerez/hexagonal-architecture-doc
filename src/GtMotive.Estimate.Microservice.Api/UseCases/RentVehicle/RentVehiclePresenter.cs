using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void RentingNoCreatedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(RentVehicleOutput response)
        {
            if (response != null)
            {
                var responseData = new RentVehicleResponse(response.Id, response.VehicleId, response.CustomerIdentity, response.StartDate);
                ActionResult = new OkObjectResult(responseData);
            }
        }
    }
}
