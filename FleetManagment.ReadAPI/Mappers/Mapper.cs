using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Mappers
{
    public class Mapper : IMapper
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
                Id = vehicle.Id,
                Vin = vehicle.VIN,
                VehicleType = vehicle.VehicleType,
                FuelType = vehicle.FuelType                
            };

            return dto;
        }

        public RequestDto ToDto(Request request)
        {
            var dto = new RequestDto()
            {
                CreatedAt = request.CreatedAt,
                VIN = (request.Vehicle == null) ? "" : request.Vehicle.VIN,
                Type = request.RequestType,
                Status = request.Status
            };

            return dto;
        }

        public FuelcardDto ToDto(Fuelcard fuelcard)
        {
            var dto = new FuelcardDto()
            {
                Number = fuelcard.CardNumber,
                FuelType = fuelcard.FuelType.ToString(),
                Services = new string[fuelcard.Services.Count]
            };

            var services = new List<string>();

            foreach(var service in fuelcard.Services)
            {
                services.Add(service.Name);
            }

            dto.Services = services.ToArray();
            return dto;
        }
    }
}
