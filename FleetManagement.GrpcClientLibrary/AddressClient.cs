using Fleetmanagement.GrpcAPI;
using System;
using System.Threading.Tasks;

namespace FleetManagement.GrpcClientLibrary
{
    public class AddressClient : ClientBase
    {
        private readonly Address.AddressClient _addressClient;

        public AddressClient(string serverUrl) : base(serverUrl)
        {
            _addressClient = new Address.AddressClient(grpcChannel);            
        }

        public AddressModel AddressDetails(int employeeId)
        {
            var address = _addressClient.GetAddress(new AddressRequest() { EmployeeId = employeeId });

            return address;
        }

        public SuccessResponse SaveAddress(AddressModel grpcAddressModel)
        {
            var response = _addressClient.SaveAddress(grpcAddressModel);

            return response;
        }
    }
}
