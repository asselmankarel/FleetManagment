using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Mappers
{
    public interface IMapper
    {
        public DriverInfo ToDto(Driver driver);

        public VehicleInfo ToDto(Vehicle vehicle);

        public RequestDto ToDto(Request request);
        
        public FuelcardDto ToDto(Fuelcard fuelcard);
    }
}
