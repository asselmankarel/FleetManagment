using AutoMapper;
using Fleetmanagement.GrpcAPI;
using Google.Protobuf.WellKnownTypes;
using System;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<FleetManagement.Domain.Models.Request, RequestModel>()
                .ForMember(destination => destination.PrefDate1,
                    opt => opt.MapFrom(source => DateTime.SpecifyKind(source.PrefDate1, DateTimeKind.Utc).ToTimestamp()))
                .ForMember(destination => destination.PrefDate2,
                    opt => opt.MapFrom(
                        source => source.PrefDate2.HasValue ? DateTime.SpecifyKind(source.PrefDate2.Value,DateTimeKind.Utc).ToTimestamp() : null));
        }
    }
}
