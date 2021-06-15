using FleetManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagment.ReadAPI.Queries;

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
        public async Task<List<Request>> GetRequestsByDriverId(int id)
        {
            return await _mediator.Send(new GetRequestsByDriverIdQuery(id));
        }

    }
}
