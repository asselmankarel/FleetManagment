﻿

using FleetManagement.Domain.Models;

namespace FleetManagement.BL.Components
{
    public interface IVehicleComponent
    {
        public Vehicle AddVehicle(Vehicle vehicle);
    }
}