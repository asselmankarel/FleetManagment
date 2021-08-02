using AutoMapper;
using Fleetmanagement.GrpcAPI;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<FleetManagement.Domain.Models.Request, RequestModel>();
        }
    }
}
