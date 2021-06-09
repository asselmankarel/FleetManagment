using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(17)]
        public string Vin { get; set; }

        public VehicleType VehicleType { get; set; }

        public FuelType FuelType { get; set; }

        public ICollection<Mileage> Mileages { get; set; }

        public ICollection<VehicleLicensePlate> VehicleLicensePlates { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; }

        public ICollection<Repair> Repairs { get; set; }

        public ICollection<DriverVehicle> DriverVehicles { get; set; }



    }
}
