using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public sealed class RentVehicleHandler : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private readonly RentVehiclePresenter rentVehiclePresenter;
        private readonly IRentVehicleUseCase rentVehicleUseCase;

        public RentVehicleHandler(RentVehiclePresenter rentVehiclePresenter, IRentVehicleUseCase rentVehicleUseCase)
        {
            this.rentVehiclePresenter = rentVehiclePresenter;
            this.rentVehicleUseCase = rentVehicleUseCase;
        }

        private RentVehicleHandler()
        {
        }

        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var input = new RentVehicleInput(request.VehicleId, request.CustomerIdentity, request.StartDate);
                await rentVehicleUseCase.Execute(input);
            }

            return rentVehiclePresenter;
        }
    }
}
