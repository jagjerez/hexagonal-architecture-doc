using System;
using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Represent Fleet entity in the domain.
    /// </summary>
    public class Fleet : IFleet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fleet"/> class.
        /// </summary>
        /// <param name="fleetCode">Represent fleet code.</param>
        /// <param name="vehicles">Represent vehicles data.</param>
        public Fleet(FleetValue fleetCode, CollectionVehicle vehicles)
        {
            FleetCode = fleetCode;
            Vehicles = vehicles;
        }

        private Fleet()
        {
        }

        /// <summary>
        /// Gets represent fleet code.
        /// </summary>
        public FleetValue FleetCode { get; private set; }

        /// <summary>
        /// Gets represent vehicles data.
        /// </summary>
        public CollectionVehicle Vehicles { get; private set; }

        /// <summary>
        /// Add new vehicle of fleet.
        /// </summary>
        /// <param name="vehicle">Represent a vehicle data.</param>
        /// <exception cref="ArgumentException">Exception if put NULL vehicle.</exception>
        /// <exception cref="DomainException">No can create a vehicle has been create.</exception>
        public void AddVehicle(IVehicle vehicle)
        {
            var vehicleDomain = (Vehicle)vehicle;
            if (vehicle == null)
            {
                throw new ArgumentException("Vehicle cannot be empty.", nameof(vehicle));
            }

            var vehicleExists = Vehicles.FindByPlateCode(vehicle.PlateCode);
            if (vehicleExists != null)
            {
                throw new DomainException($"this vehicle {vehicle.PlateCode} have created.");
            }

            if (!vehicleDomain.IsEnabled())
            {
                throw new DomainException($"this vehicle {vehicle.PlateCode} has factory date is more than 5 years.");
            }

            Vehicles.Add(vehicle);
        }
    }
}
