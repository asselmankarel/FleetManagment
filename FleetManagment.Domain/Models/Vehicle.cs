using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [StringLength(17, MinimumLength = 15)]
        [Required]
        public string Vin { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        public ICollection<Mileage> Mileages { get; set; }

        public ICollection<VehicleLicensePlate> VehicleLicensePlates { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; }

        public ICollection<Repair> Repairs { get; set; }

        public ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
