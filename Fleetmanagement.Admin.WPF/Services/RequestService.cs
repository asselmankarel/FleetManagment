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

        public async Task<List<GrpcAPI.RequestModel>> GetRequestsFromGrpcApi()
        {
            var requestList = await _requestClient.GetRequests();

            return requestList;
        }
    }
}