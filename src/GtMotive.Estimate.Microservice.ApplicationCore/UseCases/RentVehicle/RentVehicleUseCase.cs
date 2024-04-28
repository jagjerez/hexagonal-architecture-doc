using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Use case.
    /// </summary>
    internal sealed class RentVehicleUseCase : IRentVehicleUseCase
    {
        private readonly IRentVehicleOutputPort rentVehicleOutputPort;
        private readonly RentingServices rentingServices;
        private readonly IVehicleRepository vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">vehicle repository.</param>
        /// <param name="rentVehicleOutputPort">rent vehicle port.</param>
        /// <param name="rentingServices">Renting services.</param>
        public RentVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentVehicleOutputPort rentVehicleOutputPort,
            RentingServices rentingServices)
        {
            this.vehicleRepository = vehicleRepository;
            this.rentVehicleOutputPort = rentVehicleOutputPort;
            this.rentingServices = rentingServices;
        }

        private RentVehicleUseCase()
        {
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            try
            {
                var vehicle = await vehicleRepository.GetById(input.VehicleId);
                var dateEnd = DateTime.UtcNow;
                var renting = await rentingServices.RentVehicle(vehicle, input.CustomerIdentity, dateEnd);
                BuildOutput(renting);
            }
            catch (ArgumentNullException ex)
            {
                rentVehicleOutputPort.NotFoundHandle(ex.Message);
            }
            catch (ArgumentException ex)
            {
                rentVehicleOutputPort.NotFoundHandle(ex.Message);
            }
            catch (DomainException ex)
            {
                rentVehicleOutputPort.RentingNoCreatedHandle(ex.Message);
            }
        }

        private void BuildOutput(IRenting renting)
        {
            var rentingOutput = new RentVehicleOutput(renting.Id, renting.VehicleId, renting.CustomerIdentity, renting.StartDate);
            rentVehicleOutputPort.StandardHandle(rentingOutput);
        }
    }
}
