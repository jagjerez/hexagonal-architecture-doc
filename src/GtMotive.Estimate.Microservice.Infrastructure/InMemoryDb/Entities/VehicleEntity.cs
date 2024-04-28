using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryDb.Entities
{
    [Table("vehicles")]
    public class VehicleEntity : Vehicle, IVehicle
    {
        public VehicleEntity(
            Model model,
            Brand brand,
            PlateCode plateCode,
            Year matriculateYear,
            DateTime factoryDate,
            FleetValue fleetCode)
            : base(model, brand, plateCode, matriculateYear, fleetCode, factoryDate, Guid.NewGuid())
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; protected set; }

        [Column("model")]
        public override Model Model { get; protected set; }

        [Column("brand")]
        public override Brand Brand { get; protected set; }

        [Column("plateCode")]
        public override PlateCode PlateCode { get; protected set; }

        [Column("matriculateYear")]
        public override Year MatriculateYear { get; protected set; }

        [Column("fleetCode")]
        public override FleetValue FleetCode { get; protected set; }

        [Column("factoryDate")]
        public override DateTime FactoryDate { get; protected set; }
    }
}
