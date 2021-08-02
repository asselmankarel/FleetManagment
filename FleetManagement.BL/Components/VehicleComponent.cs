using FleetManagement.BL.Requests;
using FleetManagement.BL.Responses;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FleetManagement.BL.Components
{
    public class VehicleComponent : IVehicleComponent
    {
        private readonly IVehicleRepository _vehicleRepository;        

        public VehicleComponent(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public ICreateResponse Create(ICreateVehicle createVehicle) 
        {
            var vehicle = new Vehicle
            { 
                ChassisNumber = createVehicle.ChassisNumber,
                VehicleType = (VehicleType)createVehicle.VehicleType,
                FuelType = (FuelType)createVehicle.FuelType
            };

            var validationResult = IsValid(vehicle);

            if (validationResult.Successful)
            {
                vehicle.Mileages = new List<Mileage>();
                vehicle.Mileages.Add(new Mileage { Date = DateTime.Now, Km = createVehicle.Mileage });
                _vehicleRepository.Add(vehicle);                
            }

            return validationResult;
        }

        public ICreateResponse AddMileage(ICreateMileage createMileage) 
        {
            var vehicle = _vehicleRepository.GetById(createMileage.VehicleId);
            if (vehicle == null) return new CreateResponse { Successful = false, ErrorMessages = { "Vehicle not found" } };

            int lastMilage = _vehicleRepository.GetLastMileage(vehicle.Id);
            
            if (lastMilage < createMileage.Mileage)
            {
                var mileage = new Mileage { Km = createMileage.Mileage, Date = createMileage.Date };
                vehicle.Mileages.Add(mileage);
                _vehicleRepository.Update(vehicle);
                return new CreateResponse { Successful = true };
            }

            return new CreateResponse { Successful = false, ErrorMessages = { "New mileage smaller than last mileage" } };
        }


        private ICreateResponse IsValid(Vehicle vehicle)
        {
            var context = new ValidationContext(vehicle);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(vehicle, context, results, true);
            var response = new CreateResponse { Successful = isValid };
            results.ForEach(result => response.ErrorMessages.Add(result.ErrorMessage));

            return response;
        }
    }
}
