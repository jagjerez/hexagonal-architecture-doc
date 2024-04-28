using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Factories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Service for management fleet logic.
    /// </summary>
    public class FleetServices
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IFleetFactory fleetFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FleetServices"/> class.
        /// </summary>
        /// <param name="fleetFactory">Represent fleet factory.</param>
        /// <param name="vehicleRepository">Represent vehicle repository instance.</param>
        public FleetServices(
            IFleetFactory fleetFactory,
            IVehicleRepository vehicleRepository)
        {
            this.fleetFactory = fleetFactory;
            this.vehicleRepository = vehicleRepository;
        }

        private FleetServices()
        {
        }

        /// <summary>
        /// Create new vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle data.</param>
        /// <returns>Await .</returns>
        /// <exception cref="ArgumentNullException">Vehicle cannot be null.</exception>
        public async Task CreateVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            var vehicles = await vehicleRepository.GetAllVehicleByFleetCode(vehicle.FleetCode);
            var fleetData = (Fleet)fleetFactory.NewFleetAggregate(vehicle.FleetCode, vehicles);
            fleetData.AddVehicle(vehicle); // verify if is correct the vehicle data.
            await vehicleRepository.Add(vehicle);
        }
    }
}
