using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using MediatR;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddRequestHandler : IRequestHandler<AddRequestCommand, Request>
    {
        public Task<Request> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
