using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Collection
{
    /// <summary>
    /// Represent vehicle collection.
    /// </summary>
    public sealed class CollectionVehicle
    {
        private readonly List<IVehicle> _vehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionVehicle"/> class.
        /// </summary>
        public CollectionVehicle()
        {
            _vehicles = new List<IVehicle>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionVehicle"/> class.
        /// </summary>
        /// <param name="vehicles">All vehicles.</param>
        public CollectionVehicle(IEnumerable<IVehicle> vehicles)
        {
            _vehicles = vehicles.ToList();
        }

        /// <summary>
        /// Add multiple vehicle.
        /// </summary>
        /// <param name="vehicles">All vehicles.</param>
        public void Add(IEnumerable<IVehicle> vehicles)
        {
            if (vehicles == null)
            {
                throw new ArgumentNullException(nameof(vehicles));
            }

            foreach (var vehicle in vehicles)
            {
                _vehicles.Add(vehicle);
            }
        }

        /// <summary>
        /// Add new vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle.</param>
        public void Add(IVehicle vehicle) => _vehicles.Add(vehicle);

        /// <summary>
        /// Get vehicle by plate.
        /// </summary>
        /// <param name="plateCode">Plate code.</param>
        /// <returns>Return instance vehicle.</returns>
        public IVehicle FindByPlateCode(PlateCode plateCode)
        {
            return _vehicles.Find(p => p.PlateCode.Equals(plateCode));
        }

        /// <summary>
        /// Get all data collection.
        /// </summary>
        /// <returns>asEnumerable.</returns>
        public IEnumerable<IVehicle> ToList()
        {
            return _vehicles.ToList();
        }
    }
}
