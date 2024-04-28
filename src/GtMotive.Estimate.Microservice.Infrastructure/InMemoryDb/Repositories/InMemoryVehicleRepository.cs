using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Collection;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Repositories
{
    internal class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly InMemoryRentingDb _context;

        public InMemoryVehicleRepository(InMemoryRentingDb context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(IVehicle vehicle)
        {
            await _context.Vehicles.AddAsync((VehicleEntity)vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<CollectionVehicle> GetAllVehicleByFleetCode(FleetValue fleetCode)
        {
            var vehiclesCollection = await _context.Vehicles.Where(p => p.FleetCode == fleetCode).ToListAsync();

            return new CollectionVehicle(vehiclesCollection);
        }

        public async Task<IVehicle> GetById(Guid vehicleId)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(p => p.Id == vehicleId);
            return vehicle;
        }
    }
}
