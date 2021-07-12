using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetFuelcardByDriverId : IRequest<FuelcardInfo>
    {
        public int Id { get; private set; }

        public GetFuelcardByDriverId(int driverId)
        {
            Id = driverId;
        }
    }
}
