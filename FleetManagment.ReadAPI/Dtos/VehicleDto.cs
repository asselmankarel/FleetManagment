using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Dtos
{
    public class VehicleDto
    {
        public string Vin { get; set; }

        public string FuelType { get; set; }

        public string VehicleType { get; set; }
    }
}
