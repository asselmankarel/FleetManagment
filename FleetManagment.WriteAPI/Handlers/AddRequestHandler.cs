using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BL.Components;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using MediatR;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddRequestHandler : IRequestHandler<AddRequestCommand, Request>
    {
        private readonly IRequestComponent _requestComponent;

        public AddRequestHandler(IRequestComponent requestComponent)
        {
            _requestComponent = requestComponent;
        }

        public Task<Request> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestComponent.AddRequest(request.request));
        }
    }
}
