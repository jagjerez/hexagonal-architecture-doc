using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class DevolutionVehiclePresenter : IWebApiPresenter, IDevolutionVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void NotFoundHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void VehicleNoReturnedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(DevolutionVehicleOutput response)
        {
            if (response != null)
            {
                var responseData = new RentVehicleResponse(response.Id, response.VehicleId, response.CustomerIdentity, response.StartDate);
                ActionResult = new OkObjectResult(responseData);
            }
        }
    }
}
