using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Factories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.UnitOfWork;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using GtMotive.Estimate.Microservice.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            bool isDevelopment)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IVehicleFactory, EntityFactory>();
            services.AddScoped<IFleetFactory, EntityFactory>();
            services.AddScoped<IRentingFactory, EntityFactory>();

            if (!isDevelopment)
            {
                services.AddScoped(typeof(ITelemetry), typeof(AppTelemetry));
            }
            else
            {
                services.AddScoped(typeof(ITelemetry), typeof(NoOpTelemetry));
                services.AddDbContext<InMemoryRentingDb>(options =>
                        options.UseInMemoryDatabase("RentingDb"));
                services.AddScoped<IRentingRepository, InMemoryRentingRepository>();
                services.AddScoped<IVehicleRepository, InMemoryVehicleRepository>();
                services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();
            }

            return new InfrastructureBuilder(services);
        }

        private sealed class InfrastructureBuilder : IInfrastructureBuilder
        {
            public InfrastructureBuilder(IServiceCollection services)
            {
                Services = services;
            }

            public IServiceCollection Services { get; }
        }
    }
}
