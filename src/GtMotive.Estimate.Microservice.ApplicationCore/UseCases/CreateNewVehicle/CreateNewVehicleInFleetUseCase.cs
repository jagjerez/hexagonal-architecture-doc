using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Factories;
using GtMotive.Estimate.Microservice.Domain.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle
{
    /// <summary>
    /// Create new vehicle use case.
    /// </summary>
    internal class CreateNewVehicleInFleetUseCase : ICreateNewVehicleInFleetUseCase
    {
        private readonly FleetServices fleetServices;
        private readonly ICreateNewVehicleOutputPort createNewVehicleOutputPort;
        private readonly IVehicleFactory vehicleFactory;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewVehicleInFleetUseCase"/> class.
        /// </summary>
        /// <param name="fleetServices">Server domain <see cref="FleetServices"/>.</param>
        /// <param name="createNewVehicleOutputPort">output port.</param>
        /// <param name="vehicleFactory">factory vehicle.</param>
        /// <param name="unitOfWork">unit of work.</param>
        public CreateNewVehicleInFleetUseCase(
            FleetServices fleetServices,
            ICreateNewVehicleOutputPort createNewVehicleOutputPort,
            IVehicleFactory vehicleFactory,
            IUnitOfWork unitOfWork)
        {
            this.fleetServices = fleetServices;
            this.createNewVehicleOutputPort = createNewVehicleOutputPort;
            this.vehicleFactory = vehicleFactory;
            this.unitOfWork = unitOfWork;
        }

        private CreateNewVehicleInFleetUseCase()
        {
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(CreateNewVehicleInput input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input), "Input data cannot be empty.");
                }

                var vehicle = vehicleFactory.NewVehicle(input.Model, input.Brand, input.PlateCode, input.MatriculateYear, input.FactoryDate, input.FleetCode);
                await fleetServices.CreateVehicle(vehicle);

                await unitOfWork.Save();

                BuildOutput(vehicle);
            }
            catch (ArgumentNullException ex)
            {
                createNewVehicleOutputPort.NotFoundHandle(ex.Message);
            }
            catch (ArgumentException ex)
            {
                createNewVehicleOutputPort.NotFoundHandle(ex.Message);
            }
            catch (DomainException ex)
            {
                createNewVehicleOutputPort.VehicleNoCanCreateHandle(ex.Message);
            }
        }

        private void BuildOutput(IVehicle input)
        {
            var output = new CreateNewVehicleOutput(input.Model, input.Brand, input.PlateCode, input.MatriculateYear, input.FleetCode, input.FactoryDate, input.Id);

            createNewVehicleOutputPort.StandardHandle(output);
        }
    }
}
