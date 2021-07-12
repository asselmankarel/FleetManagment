using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Collections.Generic;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetMaintenancesByVehicleId : IRequest<List<MaintenanceInfo>>
    {
        public int VehicleId { get; private set; }

        public GetMaintenancesByVehicleId(int vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
