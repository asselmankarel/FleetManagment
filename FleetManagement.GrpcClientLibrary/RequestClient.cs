using Fleetmanagement.GrpcAPI;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.GrpcClientLibrary
{
    public class RequestClient : ClientBase
    {
        private readonly Request.RequestClient _requestClient;

        public RequestClient(string serverUrl) : base(serverUrl)
        {
            _requestClient = new Request.RequestClient(grpcChannel);
        }

        public async Task<List<RequestModel>> GetRequests()
        {
            var requests = new List<RequestModel>();

            using (var call = _requestClient.GetRequests(new RequestsRequest()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    var request = call.ResponseStream.Current;
                    requests.Add(request);
                }
            }

            return requests;
        }
    }
}
