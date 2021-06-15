using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BL.Components
{
    public class RequestComponent : IRequestComponent
    {

        private readonly RequestRepository _requestRepository;
        private readonly DriverRepository _driverRepository;

        public RequestComponent()
        {
            var context = new ApplicationDbContext();
            _requestRepository = new RequestRepository(context);
            _driverRepository = new DriverRepository(context);
        }

        public Request AddRequest(Request request)
        {
            var driver = _driverRepository.GetById(request.Driver.Id);
            request.Driver = driver;

            if (IsValid(request))
            {
                // TODO: check type of request and add vehicle if needed
                _requestRepository.Add(request);
                return request;
            }
            throw new ArgumentException("Request not valid!");
        }


        private bool IsValid(Request request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(request, context, results, true);
        }
    }
}
