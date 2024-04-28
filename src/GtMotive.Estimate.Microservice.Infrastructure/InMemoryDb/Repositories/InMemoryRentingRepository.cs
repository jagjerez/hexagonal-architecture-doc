using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Repositories
{
    internal class InMemoryRentingRepository : IRentingRepository
    {
        private readonly InMemoryRentingDb _context;

        public InMemoryRentingRepository(InMemoryRentingDb context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(IRenting renting)
        {
            await _context.Rentings.AddAsync((RentingEntity)renting);
            await _context.SaveChangesAsync();
        }

        public async Task<IRenting> GetRentingActiveForVehicle(Guid vehicleId)
        {
            var rentingDb = await _context.Rentings.FirstOrDefaultAsync(p => p.VehicleId == vehicleId && p.EndDate == null);

            return rentingDb;
        }

        public async Task<IRenting> GetRentingByCustomerIdentity(CustomerIdentity customerIdentity)
        {
            var rentingDb = await _context.Rentings.FirstOrDefaultAsync(p => p.CustomerIdentity == customerIdentity && p.EndDate == null);

            return rentingDb;
        }

        public async Task<IRenting> GetRentingById(Guid id)
        {
            var rentingDb = await _context.Rentings.FirstOrDefaultAsync(p => p.Id == id);

            return rentingDb;
        }

        public async Task Update(IRenting renting)
        {
            _context.Update((RentingEntity)renting);
            await _context.SaveChangesAsync();
        }
    }
}
