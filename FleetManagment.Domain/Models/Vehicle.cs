using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class Vehicle
    {
        public string ChassisNumber { get; set; }
        public string FuelType { get; set; }
        public string VehicleType { get; set; }
        public virtual ICollection<Mileage> Mileages { get; set; }
        public virtual ICollection<VehicleLicensePlate> VehicleLicensePlates { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<Repair> Repairs { get; set; }
        public virtual ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
