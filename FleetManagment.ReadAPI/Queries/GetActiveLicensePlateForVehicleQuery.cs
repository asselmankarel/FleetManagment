using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetActiveLicensePlateForVehicleQuery : IRequest<string>
    {

        public int Id { get; private set; }

        public GetActiveLicensePlateForVehicleQuery(int vehicleId)
        {
            Id = vehicleId;
        }
    }
}
