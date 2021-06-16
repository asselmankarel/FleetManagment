using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetLastMileageForVehicleQuery : IRequest<int>
    {
        public int Id { get; private set; }

        public GetLastMileageForVehicleQuery(int vehicleId)
        {
            Id = vehicleId;
        }
    }
}
