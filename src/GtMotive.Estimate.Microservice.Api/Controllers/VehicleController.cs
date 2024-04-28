using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicleOfFleet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateNewVehicle")]
        public async Task<IActionResult> CreateNewVehicle([FromBody] CreateNewVehicleRequest request)
        {
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }

        [HttpGet("GetAllVehicleOfFleet/{fleetCode}")]
        public async Task<IActionResult> GetAllVehicleOfFleet(string fleetCode)
        {
            var request = new GetAllVehicleOfFleetRequest(fleetCode);
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }
    }
}
