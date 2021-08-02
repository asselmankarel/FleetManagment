

using FleetManagement.BL.Requests;
using FleetManagement.BL.Responses;
using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BL.Components
{
    public interface IVehicleComponent
    {
        public ICreateResponse Create(ICreateVehicle createVehicle);

        public ICreateResponse AddMileage(ICreateMileage createMileage);

    }
}
