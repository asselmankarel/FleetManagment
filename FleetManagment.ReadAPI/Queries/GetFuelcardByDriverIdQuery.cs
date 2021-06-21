using FleetManagement.Domain.Models;
using MediatR;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetFuelcardByDriverIdQuery : IRequest<Fuelcard>
    {
        public int Id { get; private set; }

        public GetFuelcardByDriverIdQuery(int driverId)
        {
            Id = driverId;
        }
    }
}
