using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateNewVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DevolutionVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllVehicleOfFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateNewVehicleInFleetUseCase, CreateNewVehicleInFleetUseCase>();
            services.AddScoped<IGetAllVehicleOfFleetUseCase, GetAllVehicleOfFleetUseCase>();
            services.AddScoped<IDevolutionVehicleUseCase, DevolutionVehicleUseCase>();
            services.AddScoped<IRentVehicleUseCase, RentVehicleUseCase>();
            return services;
        }

        /// <summary>
        /// Adds Domain Services to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<FleetServices>();
            services.AddScoped<RentingServices>();
            return services;
        }
    }
}
