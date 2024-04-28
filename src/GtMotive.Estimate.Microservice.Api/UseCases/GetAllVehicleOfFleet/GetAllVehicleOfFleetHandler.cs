using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicleOfFleet
{
    public sealed class GetAllVehicleOfFleetHandler : IRequestHandler<GetAllVehicleOfFleetRequest, IWebApiPresenter>
    {
        private readonly GetAllVehicleOfFleetPresenter getAllVehicleOfFleetPresenter;
        private readonly IGetAllVehicleOfFleetUseCase getAllVehicleOfFleetUseCase;

        public GetAllVehicleOfFleetHandler(GetAllVehicleOfFleetPresenter getAllVehicleOfFleetPresenter, IGetAllVehicleOfFleetUseCase getAllVehicleOfFleetUseCase)
        {
            this.getAllVehicleOfFleetPresenter = getAllVehicleOfFleetPresenter;
            this.getAllVehicleOfFleetUseCase = getAllVehicleOfFleetUseCase;
        }

        private GetAllVehicleOfFleetHandler()
        {
        }

        public async Task<IWebApiPresenter> Handle(GetAllVehicleOfFleetRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var input = new GetAllVehicleOfFleetInput(request.FleetId);
                await getAllVehicleOfFleetUseCase.Execute(input);
            }

            return getAllVehicleOfFleetPresenter;
        }
    }
}
