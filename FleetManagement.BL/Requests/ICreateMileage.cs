using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BL.Requests
{
    public interface ICreateMileage
    {
        public int VehicleId { get; init; }

        public int Mileage { get; init; }

        public DateTime Date { get; init; }
    }
}
