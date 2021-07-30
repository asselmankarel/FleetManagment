using Fleetmanagement.GrpcAPI;
using Grpc.Core;
using Grpc.Net.Client;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FleetManagement.GrpcClientLibrary
{

    public class VehicleClient
    {
        private readonly GrpcChannel _grpcChannel;
        private readonly Vehicle.VehicleClient _vehicleClient;

        public VehicleClient(string serverAddress)
        {
            _grpcChannel = GrpcChannel.ForAddress(serverAddress);
            _vehicleClient = new Vehicle.VehicleClient(_grpcChannel);
        }

        public VehicleModel VehicleDetails(int vehicleId)
        {
            var vehicle = _vehicleClient.GetVehicle(new VehicleRequest { VehicleId = vehicleId });

            return vehicle;
        }

        public async Task<List<VehicleModel>> VehicleList()
        {
            var  vehicles = new List<VehicleModel>();
            using (var call = _vehicleClient.GetVehicles(new VehiclesRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var vehicle = call.ResponseStream.Current;
                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }

    }
}
