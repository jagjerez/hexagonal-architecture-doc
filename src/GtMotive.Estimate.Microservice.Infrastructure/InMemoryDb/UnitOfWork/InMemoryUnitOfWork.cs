using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.UnitOfWork
{
    internal class InMemoryUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly InMemoryRentingDb _context;
        private bool _disposed;

        public InMemoryUnitOfWork(InMemoryRentingDb context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
