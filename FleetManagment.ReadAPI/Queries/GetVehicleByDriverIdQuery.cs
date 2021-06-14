using FleetManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetVehicleByDriverIdQuery : IRequest<Vehicle>
    {

        public int Id { get; set; }

        public GetVehicleByDriverIdQuery(int driverId)
        {
            Id = driverId;
        }
    }
}
