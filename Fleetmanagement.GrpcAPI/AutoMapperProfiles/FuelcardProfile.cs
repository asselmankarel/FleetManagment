using AutoMapper;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class FuelcardProfile : Profile
    {
        public FuelcardProfile()
        {
            CreateMap<FleetManagement.Domain.Models.Fuelcard, FuelcardModel>();
        }
    }
}
