using Fleetmanagement.GrpcAPI;
using Grpc.Core;
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
            var vehicles = new List<VehicleModel>();
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

        public Task<VehicleModel> GetVehicleByDriverId(int driverId)
        {
            var vehicle = _vehicleClient.GetVehicleByDriverId(new VehicleByDriverIdRequest() { DriverId = driverId });

            return Task.FromResult(vehicle);
        }

        public Task<SuccessResponse> SaveVehicle(VehicleModel vehicle)
        {
            var response = _vehicleClient.SaveVehicle(vehicle);

            return Task.FromResult(response);
        }

        public Task<SuccessResponse> Delete(DeleteRequest deleteRequest)
        {
            var response = _vehicleClient.DeleteVehicle(deleteRequest);

            return Task.FromResult(response);
        }
    }
}
