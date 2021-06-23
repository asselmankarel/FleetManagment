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

        public RequestInfo ToDto(Request request);
        
        public FuelcardInfo ToDto(Fuelcard fuelcard);
    }
}
