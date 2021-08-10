using FleetManagement.BL.Requests;
using FleetManagement.BL.Responses;

namespace FleetManagement.BL.Components
{
    public interface IVehicleComponent
    {
        public ICreateResponse Create(ICreateVehicle createVehicle);

        public ICreateResponse AddMileage(ICreateMileage createMileage);

    }
}
