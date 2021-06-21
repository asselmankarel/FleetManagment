using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Dtos
{
    public class FuelcardDto
    {
        public string Number { get; set; }
        public string  FuelType { get; set; }
        public string[] Services { get; set; }
    }
}
