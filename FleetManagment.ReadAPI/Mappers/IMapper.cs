using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Mappers
{
    public interface IMapper
    {
        public DriverDto ToDto(Driver driver);

        public VehicleDto ToDto(Vehicle vehicle);

        public RequestDto ToDto(Request request);
      
    }
}
