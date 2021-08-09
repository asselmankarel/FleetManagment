using Fleetmanagement.Admin.WPF.ViewModels;
using FleetManagement.GrpcClientLibrary;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<FuelcardViewModel>> GetFuelcardsFromGrpcApi()
        {
            var fuelcardList = await _fuelcardClient.GetFuelcardList();
            var fuelcards = MapToFuelcardModel(fuelcardList);

            return fuelcards;
        }

        private List<FuelcardViewModel> MapToFuelcardModel(List<GrpcAPI.FuelcardModel> fuelcards)
        {
            var Fuelcards = new List<FuelcardViewModel>();

            foreach (var fuelcard in fuelcards)
            {
                Fuelcards.Add(new FuelcardViewModel()
                {
                    Id = fuelcard.Id,
                    CardNumber = fuelcard.CardNumber,
                    AuthType = fuelcard.AuthType,
                    FuelType = fuelcard.FuelType,
                    Services = fuelcard.Services.ToList()
                });
            }

            return Fuelcards;
        }
    }
}
