using FleetManagment.ReadAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Controllers
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
    
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> DriverRequests(int id)
        {   
            var requests = await _mediator.Send(new GetRequestsByDriverId(id));
    
            return Json(requests);
        }

        [HttpGet]
        public async Task<IActionResult> Types()
        {
            return Json(await _mediator.Send(new GetRequestTypes()));
        }

    }
}
