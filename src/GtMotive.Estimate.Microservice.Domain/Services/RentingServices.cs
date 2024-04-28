using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Factories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Renting services for management all logic for rent vehicle.
    /// </summary>
    public class RentingServices
    {
        private readonly IRentingFactory rentingFactory;
        private readonly IRentingRepository rentingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentingServices"/> class.
        /// </summary>
        /// <param name="rentingFactory">Factory renting.</param>
        /// <param name="rentingRepository">Repository renting.</param>
        public RentingServices(
            IRentingFactory rentingFactory,
            IRentingRepository rentingRepository)
        {
            this.rentingFactory = rentingFactory;
            this.rentingRepository = rentingRepository;
        }

        private RentingServices()
        {
        }

        /// <summary>
        /// Rent vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle data.</param>
        /// <param name="customerIdentity">Customer identity code.</param>
        /// <param name="startDate">Start date renting.</param>
        /// <returns>async/await.</returns>
        /// <exception cref="ArgumentNullException">Vehicle or customerIdentity cannot null.</exception>
        public async Task<IRenting> RentVehicle(IVehicle vehicle, CustomerIdentity customerIdentity, DateTime startDate)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            if (customerIdentity == null)
            {
                throw new ArgumentNullException(nameof(customerIdentity));
            }

            var rentCustomerActive = await rentingRepository.GetRentingByCustomerIdentity(customerIdentity);
            if (rentCustomerActive != null)
            {
                throw new DomainException($"The customer {customerIdentity.Value} has a rent active with the vehicle {vehicle.PlateCode}.");
            }

            var rentActive = await rentingRepository.GetRentingActiveForVehicle(vehicle.Id);
            if (rentActive != null)
            {
                throw new DomainException($"The vehicle {vehicle.PlateCode} has a rent active with the customer {customerIdentity}.");
            }

            var rent = rentingFactory.NewRenting(vehicle.Id, customerIdentity, startDate, null);
            await rentingRepository.Add(rent);
            return rent;
        }

        /// <summary>
        /// Finish vehicle.
        /// </summary>
        /// <param name="rentingId">Renting id.</param>
        /// <param name="endDate">End date of renting.</param>
        /// <returns>async/await.</returns>
        public async Task FinishRenting(Guid rentingId, DateTime endDate)
        {
            var renting = (Renting)await rentingRepository.GetRentingById(rentingId);
            if (renting == null)
            {
                throw new DomainException($"the renting {rentingId} is not exists");
            }

            if (renting.EndDate != null)
            {
                throw new DomainException($"the renting has been finished.");
            }

            renting.SetEndDate(endDate);
            await rentingRepository.Update(renting);
        }
    }
}
