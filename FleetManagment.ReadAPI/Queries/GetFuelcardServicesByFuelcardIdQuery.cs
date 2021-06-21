using FleetManagement.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetFuelcardServicesByFuelcardIdQuery : IRequest<List<FuelcardService>>
    {
        public int Id { get; private set; }

        public GetFuelcardServicesByFuelcardIdQuery(int fuelcardId)
        {
            Id = fuelcardId;
        }
    }
}
