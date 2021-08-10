using FleetManagement.BL.Components;
using FleetManagment.WriteAPI.Mappers;
using FleetManagment.WriteAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddRequest : IRequestHandler<Commands.AddRequest, Response>
    {
        private readonly IRequestComponent _requestComponent;

        public AddRequest(IRequestComponent requestComponent)
        {
            _requestComponent = requestComponent;
        }

        public Task<Response> Handle(Commands.AddRequest request, CancellationToken cancellationToken)
        {            
            var response = new Response(
                _requestComponent.Create(
                    CommandToRequestMapper.CreateRequestFromCommand(request)));

            return Task.FromResult(response);
        }


    }
}
