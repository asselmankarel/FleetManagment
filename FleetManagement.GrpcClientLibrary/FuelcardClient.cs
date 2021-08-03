using Fleetmanagement.GrpcAPI;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.GrpcClientLibrary
{
    public class FuelcardClient : ClientBase
    {
        private readonly Fuelcard.FuelcardClient _fuelcardClient;

        public FuelcardClient(string serverUrl) : base(serverUrl)
        {
            _fuelcardClient = new Fuelcard.FuelcardClient(grpcChannel);
        }

        public async Task<List<FuelcardModel>> GetFuelcardList()
        {
            var fuelcards = new List<FuelcardModel>();

            using (var call = _fuelcardClient.GetFuelcards(new FuelcardsRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {                    
                    fuelcards.Add(call.ResponseStream.Current);
                }
            }

            return fuelcards;
        }
    }
}
