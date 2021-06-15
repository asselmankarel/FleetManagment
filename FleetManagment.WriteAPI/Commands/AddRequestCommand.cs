using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using MediatR;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddRequestCommand : IRequest<Request>
    {
        public Request request { get; private set; }

        public AddRequestCommand(Request request)
        {
            this.request = request;
        }
    }
}
