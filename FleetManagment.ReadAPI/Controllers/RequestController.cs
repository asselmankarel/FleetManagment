using FleetManagment.ReadAPI.ReadModels;
using FleetManagment.ReadAPI.Mappers;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RequestController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> DriverRequests(int id)
        {   
            var requests = await _mediator.Send(new GetRequestsByDriverIdQuery(id));
            var requestDtos = new List<RequestDto>();            
            requests.ForEach(r => requestDtos.Add(_mapper.ToDto(r)));

            return Json(requestDtos);
        }

    }
}
