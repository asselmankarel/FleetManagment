using Fleetmanagement.GrpcAPI;
using Grpc.Core;
using Grpc.Net.Client;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FleetManagement.GrpcClientLibrary
{
    public class VehicleClient : ClientBase
    {
 
        private readonly Vehicle.VehicleClient _vehicleClient;

        public VehicleClient(string serverUrl) : base(serverUrl)
        {
            _vehicleClient = new Vehicle.VehicleClient(grpcChannel);
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
