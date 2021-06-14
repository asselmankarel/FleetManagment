using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FleetManagement.BL.Components
{
    public class VehicleComponent
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleComponent()
        {
            _vehicleRepository = new VehicleRepository(new ApplicationDbContext());
        }

        public Vehicle AddVehilce(Vehicle vehicle)
        {
            if (IsValid(vehicle))
            {
                _vehicleRepository.Add(vehicle);   
            }
            return vehicle;
        }

        private bool IsValid(Vehicle vehicle)
        {
            var context = new ValidationContext(vehicle);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(vehicle, context, results, true);
        }

    }
}
