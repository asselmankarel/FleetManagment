using FleetManagement.BL.Responses;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FleetManagement.BL.Components
{
    public class DriverComponent : IDriverComponent
    {
        private readonly DriverRepository _driverRepository;

        public DriverComponent()
        {
            _driverRepository = new DriverRepository(new ApplicationDbContext());
        }

        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetById(id);
        }

        public async Task<ICreateResponse> SaveDriver(Driver driver)
        {
            var response = IsValid(driver);
            if (response.Successful)
            {
                try
                {
                    if (driver.Id == 0)
                    {
                        await _driverRepository.AddAsync(driver);
                    }
                    else
                    {
                        await _driverRepository.UpdateAsync(driver);
                    }
                    
                    response = new CreateResponse() { Successful = true, ErrorMessages = { "Driver saved."}};
                }
                catch (Exception ex)
                {
                    response = new CreateResponse() { Successful = false, ErrorMessages = { $"Unable to save driver: {ex.Message}" }};
                }
            }

            return response;
        }

        private static ICreateResponse IsValid(Driver driver)
        {
            var context = new ValidationContext(driver);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(driver, context, results, true);
            var response = new CreateResponse { Successful = success };
            results.ForEach(result => response.ErrorMessages.Add(result.ErrorMessage));

            return response;
        } 

    }
}
