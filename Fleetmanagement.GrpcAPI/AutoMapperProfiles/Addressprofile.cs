using AutoMapper;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class Addressprofile : Profile
    {
        public Addressprofile()
        {
            CreateMap<FleetManagement.Domain.Models.Address, AddressModel>();
            CreateMap<AddressModel, FleetManagement.Domain.Models.Address>();
        }
    }
}
