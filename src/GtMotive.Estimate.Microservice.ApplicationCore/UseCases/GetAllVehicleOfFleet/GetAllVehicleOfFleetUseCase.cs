using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet
{
    /// <summary>
    /// Get all vehicle of fleet use case.
    /// </summary>
    internal sealed class GetAllVehicleOfFleetUseCase : IGetAllVehicleOfFleetUseCase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IGetAllVehicleOfFleetOutputPort getAllVehicleOfFleetOutputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehicleOfFleetUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">vehicle repository.</param>
        /// <param name="getAllVehicleOfFleetOutputPort">get all vehicles of fleet.</param>
        public GetAllVehicleOfFleetUseCase(
            IVehicleRepository vehicleRepository,
            IGetAllVehicleOfFleetOutputPort getAllVehicleOfFleetOutputPort)
        {
            this.vehicleRepository = vehicleRepository;
            this.getAllVehicleOfFleetOutputPort = getAllVehicleOfFleetOutputPort;
        }

        private GetAllVehicleOfFleetUseCase()
        {
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAllVehicleOfFleetInput input)
        {
            try
            {
                var vehicles = await vehicleRepository.GetAllVehicleByFleetCode(input.FleetCode);
                BuildOutput(vehicles);
            }
            catch (ArgumentNullException ex)
            {
                getAllVehicleOfFleetOutputPort.NotFoundHandle(ex.Message);
            }
            catch (ArgumentException ex)
            {
                getAllVehicleOfFleetOutputPort.NotFoundHandle(ex.Message);
            }
            catch (DomainException ex)
            {
                getAllVehicleOfFleetOutputPort.FleetNoHasVehiclesHandle(ex.Message);
            }
        }

        private void BuildOutput(CollectionVehicle vehicles)
        {
            var output = new GetAllVehicleOfFleetOutput(vehicles.ToList());

            getAllVehicleOfFleetOutputPort.StandardHandle(output);
        }
    }
}
