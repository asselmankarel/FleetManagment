using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Enums;
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
        private readonly VehicleRepository _vehicleRepository;

        public RequestComponent()
        {
            var context = new ApplicationDbContext();
            _requestRepository = new RequestRepository(context);
            _driverRepository = new DriverRepository(context);
            _vehicleRepository = new VehicleRepository(context);
        }

        public Request AddRequest(Request request)
        {
            var driver = _driverRepository.GetById(request.Driver.Id);
            request.Driver = driver;

            if (IsValid(request))
            {
                if (RequestRequiresCar(request))
                {
                    request.Vehicle = _vehicleRepository.GetCurrentVehicleForDriver(request.Driver.Id);
                }
                _requestRepository.Add(request);
                return request;
            }
            throw new ArgumentException("Request not valid!");
        }

        private bool RequestRequiresCar(Request request)
        {
            switch (request.RequestType)
            {
                case RequestType.Maintenance: return true;
                case RequestType.Repair: return true;
                default: return false;
            }            
        }

        private bool IsValid(Request request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(request, context, results, true);
        }
    }
}
