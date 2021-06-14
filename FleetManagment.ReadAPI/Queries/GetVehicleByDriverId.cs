using FleetManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetVehicleByDriverId : IRequest<Vehicle>
    {
        private int Id;

        public GetVehicleByDriverId(int driverId)
        {
            Id = driverId;
        }
    }
}
