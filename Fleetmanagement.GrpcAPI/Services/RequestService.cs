using AutoMapper;
using Fleetmanagement.GrpcAPI;
using FleetManagement.BL.Components;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcAPI.Services
{
    public class RequestService : Request.RequestBase
    {
        private readonly ILogger<RequestService> _logger;
        private readonly IRequestComponent _requestComponent;
        private readonly IMapper _mapper;

        public RequestService(ILogger<RequestService> logger, IRequestComponent requestComponent, IMapper mapper)
        {
            _logger = logger;
            _requestComponent = requestComponent;
            _mapper = mapper;
        }

        public override async Task GetRequests(RequestsRequest request, IServerStreamWriter<RequestModel> responseStream, ServerCallContext context)
        {
            var requests = await _requestComponent.GetRequests();

            foreach(var req in requests)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("Request cancelled!");
                    break;
                }

                await responseStream.WriteAsync(_mapper.Map<RequestModel>(req));
            }
        }
    }
}
