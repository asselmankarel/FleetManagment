using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BL.Requests
{
    public interface ICreateVehicle
    {
        public string ChassisNumber { get; init; }
        
        public int VehicleType { get; init; }

        public int FuelType { get; init; }

        public int Mileage { get; init; }

    }
}
