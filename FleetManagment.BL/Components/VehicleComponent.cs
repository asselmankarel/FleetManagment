using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BL.Components
{
    public class VehicleComponent : IVehicleComponent
    {
        private readonly IVehicleRepository _vehicleRepository;        

        public VehicleComponent(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle Create(string chassisNumber, int vehicleType, int fuelType, int currentMileage)
        {
            var vehicle = new Vehicle() { ChassisNumber = chassisNumber, VehicleType = (VehicleType)vehicleType, FuelType = (FuelType)fuelType};
            if (IsValid(vehicle))
            {
                vehicle.Mileages = new List<Mileage>();
                vehicle.Mileages.Add(new Mileage { Date = DateTime.Now, Km = currentMileage });
                _vehicleRepository.Add(vehicle);

                return vehicle;
            }

            throw new ArgumentException("Vehicle information not valid!");
        }

        private bool IsValid(Vehicle vehicle)
        {
            var context = new ValidationContext(vehicle);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(vehicle, context, results, true);
        }

    }
}
