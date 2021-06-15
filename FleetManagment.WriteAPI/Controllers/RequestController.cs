using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using FleetManagment.WriteAPI.Dtos;
using FleetManagment.WriteAPI.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RequestController : Controller
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Request> AddRequest(RequestDto requestDto)
        {
            Request request = Mapper.FromDto(requestDto);
            
            return await _mediator.Send(new AddRequestCommand(request));
        }

    }
}
