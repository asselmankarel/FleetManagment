﻿using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class Vehicle
    {
        public string ChassisNumber { get; set; }
        public string FuelType { get; set; }
        public string VehicleType { get; set; }
        public ICollection<Mileage> Mileages { get; set; }
        public ICollection<VehicleLicensePlate> VehicleLicensePlates { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
        public ICollection<Repair> Repairs { get; set; }

    }
}
