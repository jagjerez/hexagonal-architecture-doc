using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle
{
    public sealed class CreateNewVehicleHandler : IRequestHandler<CreateNewVehicleRequest, IWebApiPresenter>
    {
        private readonly CreateNewVehiclePresenter createNewVehiclePresenter;
        private readonly ICreateNewVehicleInFleetUseCase createNewVehicleInFleetUseCase;

        public CreateNewVehicleHandler(CreateNewVehiclePresenter createNewVehiclePresenter, ICreateNewVehicleInFleetUseCase createNewVehicleInFleetUseCase)
        {
            this.createNewVehicleInFleetUseCase = createNewVehicleInFleetUseCase;
            this.createNewVehiclePresenter = createNewVehiclePresenter;
        }

        private CreateNewVehicleHandler()
        {
        }

        public async Task<IWebApiPresenter> Handle(CreateNewVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var input = new CreateNewVehicleInput(request.Model, request.Brand, request.PlateCode, request.MatriculateYear, request.FactoryDate, request.FleetCode);
                await createNewVehicleInFleetUseCase.Execute(input);
            }

            return createNewVehiclePresenter;
        }
    }
}
