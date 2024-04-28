using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RentingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("RentingVehicle")]
        public async Task<IActionResult> RentingVehicle([FromBody] RentVehicleRequest request)
        {
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }

        [HttpPost("DevolutionVehicle")]
        public async Task<IActionResult> DevolutionVehicle([FromBody] DevolutionVehicleRequest request)
        {
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }
    }
}
