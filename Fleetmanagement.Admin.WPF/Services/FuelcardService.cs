using FleetManagement.GrpcClientLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class FuelcardService : ServiceBase
    {
        private readonly FuelcardClient _fuelcardClient;

        public FuelcardService()
        {
            _fuelcardClient = new FuelcardClient(_grpcServerUrl);
        }

        public async Task<List<GrpcAPI.FuelcardModel>> GetFuelcardsFromGrpcApi()
        {
            var fuelcards = await _fuelcardClient.GetFuelcardList();

            return fuelcards;
        }
    }
}
