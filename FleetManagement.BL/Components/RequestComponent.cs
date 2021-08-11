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
    public class RequestComponent : IRequestComponent
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public RequestComponent(IRequestRepository requestRepository, IDriverRepository driverRepository, IVehicleRepository vehicleRepository)
        {
            _requestRepository = requestRepository;
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<RequestRequest>> GetRequests()
        {
            List<RequestRequest> requests = await _requestRepository.GetRequests();

            return requests;
        }

        public ICreateResponse Create(ICreateRequest createRequest)
        {
            if (!DriverExists(createRequest.DriverId)) return GenerateFailedResponse("Driver not found...");

            RequestRequest request = MapCreateRequestToRequest(createRequest);
            ICreateResponse createResponse = IsValid(request);

            if (!createResponse.Successful) return createResponse;

            if (RequiresCar(request))
            {
                request.Vehicle = _vehicleRepository.GetCurrentVehicleForDriver(request.Driver.Id);
                if (request.Vehicle == null) return GenerateFailedResponse("No vehicle found for driver...");
            }
            _requestRepository.Add(request);

            return new CreateResponse { Successful = true };
        }

        private bool DriverExists(int driverId)
        {
            return _driverRepository.GetById(driverId) != null;
        }

        private static ICreateResponse GenerateFailedResponse(string error)
        {
            return new CreateResponse
            {
                Successful = false,
                ErrorMessages = { error }
            };
        }

        private RequestRequest MapCreateRequestToRequest(ICreateRequest createRequest)
        {
            Driver driver = _driverRepository.GetById(createRequest.DriverId);

            return new RequestRequest
            {
                Driver = driver,
                RequestType = (RequestType)createRequest.RequestType,
                PrefDate1 = createRequest.PrefDate1,
                PrefDate2 = (createRequest.PrefDate2.Year < DateTime.Now.Year) ? null : createRequest.PrefDate2
            };
        }

        private static bool RequiresCar(RequestRequest request)
        {
            switch (request.RequestType)
            {
                case RequestType.Maintenance: return true;
                case RequestType.Repair: return true;
                default: return false;
            }
        }

        private static ICreateResponse IsValid(RequestRequest request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(request, context, results, true);
            
            var response = new CreateResponse { Successful = success };
            results.ForEach(result => response.ErrorMessages.Add(result.ErrorMessage));

            return response;
        }

    }
}
