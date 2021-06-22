using FleetManagment.ReadAPI.ReadModels;
using MediatR;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetVehicleByDriverId : IRequest<VehicleInfo>
    {
        public int Id { get; private set; }

        public GetVehicleByDriverId(int driverId)
        {
            Id = driverId;
        }
    }
}
