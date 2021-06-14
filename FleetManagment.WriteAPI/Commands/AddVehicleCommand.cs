using FleetManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddVehicleCommand :IRequest<Vehicle>
    {
        public Vehicle vehicle { get; private set; }

        public AddVehicleCommand(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }
    }
}
