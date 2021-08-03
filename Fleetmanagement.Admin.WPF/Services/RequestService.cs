using Fleetmanagement.Admin.WPF.Models;
using FleetManagement.Admin.WPF.Models;
using FleetManagement.GrpcClientLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class RequestService : ServiceBase
    {
        private readonly RequestClient _requestClient;

        public RequestService()
        {
            _requestClient = new RequestClient(_grpcServerUrl);
        }

        public async Task<List<RequestModel>> GetRequestsFromGrpcApi()
        {
            var requestList = await _requestClient.GetRequests();
            var requests = MapToRequestModel(requestList);

            return requests;
        }

        private List<RequestModel> MapToRequestModel(List<GrpcAPI.RequestModel> requests)
        {
            var Requests = new List<RequestModel>();

            foreach (var request in requests)
            {
                Requests.Add(new RequestModel()
                {
                    Id = request.Id,
                    RequestType = request.RequestType,
                    Status = request.Status,
                    PrefDate1 = request.PrefDate1.ToDateTime(),
                    //PrefDate2 = request?.PrefDate2 == null ? request.PrefDate2.ToDateTime() : null,
                    Driver = MapToDriver(request.Driver),
                    Vehicle = MapToVehicle(request.Vehicle)
                });
            }

            return Requests;
        }

        private VehicleModel MapToVehicle(GrpcAPI.VehicleModel vehicle)
        {
            if (vehicle == null) return null;

            return new VehicleModel()
            {
                Id = vehicle.Id,
                ChassisNumber = vehicle.ChassisNumber,
                VehicleType = vehicle.VehicleType,
                FuelType = vehicle.FuelType,
                Licenseplate = vehicle.Licenseplate
            };
        }

        private DriverModel MapToDriver(GrpcAPI.DriverModel driver)
        {
            return new DriverModel()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                NationalIdentificationNumber = driver.NationalIdentificationNumber,
                Email = driver.Email,
                IsActive = driver.IsActive,
                DriversLicense = driver.DriversLicense
            };
        }
    }
}