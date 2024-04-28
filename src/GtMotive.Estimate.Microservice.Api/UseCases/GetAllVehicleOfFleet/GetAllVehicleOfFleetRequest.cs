using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicleOfFleet
{
    public sealed class GetAllVehicleOfFleetRequest : IRequest<IWebApiPresenter>
    {
        public GetAllVehicleOfFleetRequest(string fleedId)
        {
            FleetId = new FleetValue(fleedId);
        }

        public FleetValue FleetId { get; private set; }
    }
}
