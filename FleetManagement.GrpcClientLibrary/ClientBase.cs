using Fleetmanagement.GrpcAPI;
using Grpc.Core;
using Grpc.Net.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.GrpcClientLibrary
{
    public abstract class ClientBase
    {
        public readonly GrpcChannel grpcChannel;

        public ClientBase(string serverUrl)
        {
            grpcChannel = GrpcChannel.ForAddress(serverUrl);
        }
    }
}
