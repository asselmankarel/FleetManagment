using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BL.Components
{
    public class VehicleComponent
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleComponent()
        {
            _vehicleRepository = new VehicleRepository(new ApplicationDbContext());
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            if (IsValid(vehicle))
            {
                vehicle.Mileages = new List<Mileage>();
                vehicle.Mileages.Add(new Mileage { Date = DateTime.Now, Km = 0 });
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
