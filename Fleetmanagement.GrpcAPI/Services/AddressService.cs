using AutoMapper;
using FleetManagement.DAL.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcAPI.Services
{
    public class AddressService : Address.AddressBase
    {
        private readonly ILogger<DriverService> _logger;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(ILogger<DriverService> logger, IAddressRepository addressRepository, IMapper mapper)
        {
            _logger = logger;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public override async Task<AddressModel> GetAddress(AddressRequest request, ServerCallContext context)
        {
            var address = _mapper.Map<AddressModel>(await _addressRepository.GetAddressByDriverId(request.EmployeeId));

            if (address == null) return new AddressModel() { EmployeeId = request.EmployeeId };

            return address;
        }

        public override Task<SuccessResponse> SaveAddress(AddressModel request, ServerCallContext context)
        {
            var address = _mapper.Map<FleetManagement.Domain.Models.Address>(request);
            try
            {
                var nbr = _addressRepository.Update(address);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new SuccessResponse() { SuccessFul = false, ErrorMessage = ex.Message });
            }

            return Task.FromResult(new SuccessResponse() { SuccessFul = true, ErrorMessage = "Address saved." });
        }

    }
}
