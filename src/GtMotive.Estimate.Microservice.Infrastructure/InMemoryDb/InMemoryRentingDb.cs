using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb
{
    internal class InMemoryRentingDb : DbContext
    {
        public InMemoryRentingDb(DbContextOptions<InMemoryRentingDb> options)
        : base(options)
        {
        }

        public DbSet<VehicleEntity> Vehicles { get; set; }

        public DbSet<RentingEntity> Rentings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<VehicleEntity>()
                .Property(p => p.Model)
                .HasConversion(
                    v => v.Value,
                    v => new Model(v));

            modelBuilder.Entity<VehicleEntity>()
                .Property(p => p.Brand)
                .HasConversion(
                    v => v.Value,
                    v => new Brand(v));

            modelBuilder.Entity<VehicleEntity>()
                .Property(p => p.MatriculateYear)
                .HasConversion(
                    v => v.Value,
                    v => new Year(v));

            modelBuilder.Entity<VehicleEntity>()
                .Property(p => p.PlateCode)
                .HasConversion(
                    v => v.Value,
                    v => new PlateCode(v));

            modelBuilder.Entity<VehicleEntity>()
                .Property(p => p.FleetCode)
                .HasConversion(
                    v => v.Value,
                    v => new FleetValue(v));

            modelBuilder.Entity<RentingEntity>()
                .Property(p => p.CustomerIdentity)
                .HasConversion(
                    v => v.Value,
                    v => new CustomerIdentity(v));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InMemoryRentingDb).Assembly);
        }
    }
}
