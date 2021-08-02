using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<FleetManagement.Domain.Models.Vehicle, VehicleModel>()
                .ForMember(
                    destination => destination.Licenseplate,
                    opt => opt.MapFrom(source => source.VehicleLicensePlates.First().LicensePlate.Number));
        }
    }
}
