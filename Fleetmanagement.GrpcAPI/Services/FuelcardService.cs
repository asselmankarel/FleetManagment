using AutoMapper;
using FleetManagement.DAL.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcAPI.Services
{
    public class FuelcardService : Fuelcard.FuelcardBase
    {
        private readonly ILogger<FuelcardService> _logger;
        private readonly IFuelcardRepository _fuelcardRepository;
        private readonly IMapper _mapper;

        public FuelcardService(ILogger<FuelcardService> logger, IFuelcardRepository fuelcardRepository, IMapper mapper)
        {
            _logger = logger;
            _fuelcardRepository = fuelcardRepository;
            _mapper = mapper;
        }

        public override async Task GetFuelcards(FuelcardsRequest request, IServerStreamWriter<FuelcardModel> responseStream, ServerCallContext context)
        {
            var fuelcards = await _fuelcardRepository.GetAllFuelcardsWithServices();

            foreach (var fuelcard in fuelcards)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("Request cancelled!");
                    break;
                }
                
                var fuelcardModel = new FuelcardModel()
                {
                    Id = fuelcard.Id,
                    CardNumber = fuelcard.CardNumber,
                    AuthType = fuelcard.AuthType.ToString(),
                    FuelType = fuelcard.FuelType.ToString(),
                };
                
                fuelcardModel.Services.Clear();
                fuelcardModel.Services.AddRange(GetServiceNames(fuelcard.Services));

                await responseStream.WriteAsync(fuelcardModel);
            }
        }

        private Google.Protobuf.Collections.RepeatedField<string> GetServiceNames(ICollection<FleetManagement.Domain.Models.FuelcardService> services)
        {
            var serviceList = new Google.Protobuf.Collections.RepeatedField<string>();

            foreach (var service in services)
            {
                serviceList.Add(service.Name);
            }

            return serviceList;
        }
    }
}
