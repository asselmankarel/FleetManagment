using AutoMapper;
using Fleetmanagement.Admin.WPF.ViewModels;

namespace Fleetmanagement.Admin.WPF.AutoMapperProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<GrpcAPI.VehicleModel, VehicleViewModel>();
            CreateMap<VehicleViewModel, GrpcAPI.VehicleModel>()
                .ForSourceMember(src => src.Licenseplate, opt => opt.DoNotValidate())
                .ForMember(dest => dest.Licenseplate, opt => opt.Ignore());
        }
    }
}
