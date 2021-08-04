using AutoMapper;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<FleetManagement.Domain.Models.Driver, DriverModel>();
            CreateMap<DriverModel, FleetManagement.Domain.Models.Driver>();            
        }
    }
}
