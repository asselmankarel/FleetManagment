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

        public bool AddRequest(int driverId, int requestType, DateTime prefDate1, DateTime prefDate2)
        {
            var driver = _driverRepository.GetById(driverId);
            if (driver == null) return false;

            var request = new Request() {
                Driver = driver,
                RequestType = (RequestType)requestType,
                PrefDate1 = prefDate1,
                PrefDate2 = (prefDate2.Year < DateTime.Now.Year) ? null : prefDate2 
            };

            if (!RequestIsValid(request)) return false;
            
            if (RequestRequiresCar(request))
            {
                request.Vehicle = _vehicleRepository.GetCurrentVehicleForDriver(request.Driver.Id);
            }
            _requestRepository.Add(request);

            return true;
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

        private bool RequestIsValid(Request request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(request, context, results, true);
        }
    }
}
