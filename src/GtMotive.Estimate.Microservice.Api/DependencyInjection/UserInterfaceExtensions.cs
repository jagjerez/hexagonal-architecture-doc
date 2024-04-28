using GtMotive.Estimate.Microservice.Api.UseCases.CreateNewVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllVehicleOfFleet;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateNewVehiclePresenter>();
            services.AddScoped<GetAllVehicleOfFleetPresenter>();
            services.AddScoped<DevolutionVehiclePresenter>();
            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<ICreateNewVehicleOutputPort>(provider => provider.GetService<CreateNewVehiclePresenter>());
            services.AddScoped<IGetAllVehicleOfFleetOutputPort>(provider => provider.GetService<GetAllVehicleOfFleetPresenter>());
            services.AddScoped<IDevolutionVehicleOutputPort>(provider => provider.GetService<DevolutionVehiclePresenter>());
            services.AddScoped<IRentVehicleOutputPort>(provider => provider.GetService<RentVehiclePresenter>());
            return services;
        }
    }
}
