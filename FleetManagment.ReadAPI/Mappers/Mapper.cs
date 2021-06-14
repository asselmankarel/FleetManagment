using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Mappers
{
    public class Mapper
    {

        public DriverDto ToDto(Driver driver)
        {
            var dto = new DriverDto() {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                DriversLicense = driver.DriversLicense.ToString()
            };

            return dto;
        }

        public VehicleDto ToDto(Vehicle vehicle)
        {

            var dto = new VehicleDto()
            {
                Vin = vehicle.Vin,
                VehicleType = vehicle.VehicleType.ToString(),
                FuelType = vehicle.FuelType.ToString()                
            };

            return dto;
        }
    }
}
