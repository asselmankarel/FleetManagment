using AutoMapper;
using Fleetmanagement.GrpcAPI;
using FleetManagement.BL.Components;
using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
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

        public override Task<SuccessResponse> SaveRequest(RequestModel request, ServerCallContext context)
        {    
            try
            {
                var requestRequest = new RequestRequest
                {
                    Id = request.Id,
                    Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), request.Status)
                };
                _requestComponent.UpdateRequestStatus(requestRequest);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new SuccessResponse {SuccessFul = false, ErrorMessage = ex.Message });
            }

            return Task.FromResult(new SuccessResponse { SuccessFul = true });
        }
    }
}
