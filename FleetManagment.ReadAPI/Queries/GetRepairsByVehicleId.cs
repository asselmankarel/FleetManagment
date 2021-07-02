using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Collections.Generic;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetRepairsByVehicleId : IRequest<List<RepairInfo>>
    {

        public int VehicleId { get; private set; }

        public GetRepairsByVehicleId(int vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
