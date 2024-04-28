using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class DevolutionVehicleHandler : IRequestHandler<DevolutionVehicleRequest, IWebApiPresenter>
    {
        private readonly DevolutionVehiclePresenter devolutionVehiclePresenter;
        private readonly IDevolutionVehicleUseCase devolutionVehicleUseCase;

        public DevolutionVehicleHandler(DevolutionVehiclePresenter devolutionVehiclePresenter, IDevolutionVehicleUseCase devolutionVehicleUseCase)
        {
            this.devolutionVehiclePresenter = devolutionVehiclePresenter;
            this.devolutionVehicleUseCase = devolutionVehicleUseCase;
        }

        private DevolutionVehicleHandler()
        {
        }

        public async Task<IWebApiPresenter> Handle(DevolutionVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var input = new DevolutionVehicleInput(request.Id);
                await devolutionVehicleUseCase.Execute(input);
            }

            return devolutionVehiclePresenter;
        }
    }
}
