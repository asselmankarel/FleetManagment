using AutoMapper;
using System.Linq;

namespace Fleetmanagement.GrpcAPI.AutoMapperProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<FleetManagement.Domain.Models.Vehicle, VehicleModel>()
                .ForMember(
                    destination => destination.Licenseplate,
                    opt => opt.MapFrom(
                        source => source.VehicleLicensePlates.Count == 0 ? "" : source.VehicleLicensePlates.First().LicensePlate.Number));

            CreateMap<VehicleModel, FleetManagement.Domain.Models.Vehicle>()
                .ForSourceMember(source => source.Licenseplate, opt => opt.DoNotValidate())
                .ForMember(dest => dest.VehicleLicensePlates, opt => opt.Ignore());
        }
    }
}
