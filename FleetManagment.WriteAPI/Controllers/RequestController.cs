using FleetManagment.WriteAPI.Commands;
using FleetManagment.WriteAPI.Models;
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
        public async Task<Response> New(RequestPostModel postedData)
        {
            return await _mediator.Send(new AddRequestCommand(postedData.driverId, postedData.Type, postedData.PrefDate1, postedData.PrefDate2));
        }

    }
}
