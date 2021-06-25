using FleetManagement.BL.Components;
using FleetManagment.WriteAPI.Commands;
using FleetManagment.WriteAPI.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddRequestHandler : IRequestHandler<AddRequestCommand, Response>
    {
        private readonly IRequestComponent _requestComponent;

        public AddRequestHandler(IRequestComponent requestComponent)
        {
            _requestComponent = requestComponent;
        }

        public Task<Response> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new Response(_requestComponent.AddRequest(request.DriverId, request.RequestType, request.PrefDate1, request.PrefDate2), "");

            return Task.FromResult(response);
        }


    }
}
