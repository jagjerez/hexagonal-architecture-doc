using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Entities
{
    public class RentingEntity : Renting, IRenting
    {
        public RentingEntity(
            Guid vehicleId,
            CustomerIdentity customerIdentity,
            DateTime startDate,
            DateTime? endDate)
            : base(Guid.NewGuid(), vehicleId, customerIdentity, startDate, endDate)
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; protected set; }

        [Column("vehicleId")]
        public override Guid VehicleId { get; protected set; }

        [Column("customerIdentity")]
        public override CustomerIdentity CustomerIdentity { get; protected set; }

        [Column("startDate")]
        public override DateTime StartDate { get; protected set; }

        [Column("endDate")]
        public override DateTime? EndDate { get; protected set; }
    }
}
