using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BL.Components;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using MediatR;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, Vehicle>
    {
        private readonly VehicleComponent _vehicleComponent;

        public Task<Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleComponent.AddVehilce(request.vehicle));            
        }
    }
}
