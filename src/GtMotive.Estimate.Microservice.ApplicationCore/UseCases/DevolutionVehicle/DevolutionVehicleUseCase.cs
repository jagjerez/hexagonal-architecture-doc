using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle
{
    /// <summary>
    /// Use case.
    /// </summary>
    internal sealed class DevolutionVehicleUseCase : IDevolutionVehicleUseCase
    {
        private readonly IDevolutionVehicleOutputPort devolutionVehicleOutputPort;
        private readonly IRentingRepository rentingRepository;
        private readonly RentingServices rentingServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevolutionVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentingRepository">Renting repository.</param>
        /// <param name="devolutionVehicleOutputPort">Devolution vehicle port.</param>
        /// <param name="rentingServices">Renting services.</param>
        public DevolutionVehicleUseCase(
            IRentingRepository rentingRepository,
            IDevolutionVehicleOutputPort devolutionVehicleOutputPort,
            RentingServices rentingServices)
        {
            this.rentingServices = rentingServices;
            this.rentingRepository = rentingRepository;
            this.devolutionVehicleOutputPort = devolutionVehicleOutputPort;
        }

        private DevolutionVehicleUseCase()
        {
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DevolutionVehicleInput input)
        {
            try
            {
                var dateEnd = DateTime.UtcNow;
                await rentingServices.FinishRenting(input.RentId, dateEnd);
                var renting = await rentingRepository.GetRentingById(input.RentId);
                BuildOutput(renting);
            }
            catch (ArgumentNullException ex)
            {
                devolutionVehicleOutputPort.NotFoundHandle(ex.Message);
            }
            catch (ArgumentException ex)
            {
                devolutionVehicleOutputPort.NotFoundHandle(ex.Message);
            }
            catch (DomainException ex)
            {
                devolutionVehicleOutputPort.VehicleNoReturnedHandle(ex.Message);
            }
        }

        private void BuildOutput(IRenting renting)
        {
            var rentingOutput = new DevolutionVehicleOutput(renting.Id, renting.VehicleId, renting.CustomerIdentity, renting.StartDate, renting.EndDate);
            devolutionVehicleOutputPort.StandardHandle(rentingOutput);
        }
    }
}
