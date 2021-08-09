using Fleetmanagement.Admin.WPF.ViewModels;
using FleetManagement.GrpcClientLibrary;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class AddressService : ServiceBase
    {
        private readonly AddressClient _addressClient;

        public AddressService()
        {
            _addressClient = new AddressClient(_grpcServerUrl);
        }

        public AddressViewModel GetAddress(int driverId)
        {
            var address = _addressClient.AddressDetails(driverId);

            return new AddressViewModel()
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                Box = address.Box,
                PostalCode = address.PostalCode,
                City = address.City,
                Country = address.Country,
                EmployeeId = address.EmployeeId
            };
        }

        public GrpcAPI.SuccessResponse SaveAddress(AddressViewModel address)
        {
            var grpcAddressModel = new GrpcAPI.AddressModel()
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                Box = address.Box,
                PostalCode = address.PostalCode,
                City = address.City,
                Country = address.Country,
                EmployeeId = address.EmployeeId
            };

            var response = _addressClient.SaveAddress(grpcAddressModel);

            return response;
        }
    }
}
