using FleetManagement.BL.Requests;
using FleetManagement.BL.Responses;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FleetManagement.BL.Components
{
    public class RequestComponent : IRequestComponent
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public RequestComponent(IRequestRepository requestRepository, IDriverRepository driverRpository, IVehicleRepository vehicleRepository)
        {
            _requestRepository = requestRepository;
            _driverRepository = driverRpository;
            _vehicleRepository = vehicleRepository;
        }

        public ICreateResponse Create(ICreateRequest createRequest)
        {
            var driver = _driverRepository.GetById(createRequest.DriverId);
            if (driver == null) return MakeFailedResponse("Driver not found...");

            var request = MakeRequest(driver, createRequest);
            CreateResponse createResponse = IsValid(request);

            if (!createResponse.SuccessFul) return createResponse;            

            if (RequiresCar(request))
            {
                request.Vehicle = _vehicleRepository.GetCurrentVehicleForDriver(request.Driver.Id);
                if (request.Vehicle == null) return MakeFailedResponse("No vehicle found for driver...");
            }
            _requestRepository.Add(request);

            return new CreateResponse() { SuccessFul = true };
        }

        private static ICreateResponse MakeFailedResponse(string error)
        {
            return new CreateResponse()
            {
                SuccessFul = false,
                ErrorMessages = new string[] { error }
            };
        }

        private static Request MakeRequest(Driver driver, ICreateRequest createRequest)
        {
            return new Request() {
                Driver = driver,
                RequestType = (RequestType)createRequest.RequestType,
                PrefDate1 = createRequest.PrefDate1,
                PrefDate2 = (createRequest.PrefDate2.Year < DateTime.Now.Year) ? null : createRequest.PrefDate2
            };
        }

        private static bool RequiresCar(Request request)
        {
            switch (request.RequestType)
            {
                case RequestType.Maintenance: return true;
                case RequestType.Repair: return true;
                default: return false;
            }            
        }

        private static CreateResponse IsValid(Request request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(request, context, results, true);
            var messages = new List<string>();
            results.ForEach(result => messages.Add(result.ErrorMessage));

            return new CreateResponse() { SuccessFul = success, ErrorMessages = messages.ToArray()};
        }
    }
}
