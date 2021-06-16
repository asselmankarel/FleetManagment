using FleetManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagment.ReadAPI.Queries;
using Newtonsoft.Json;
using FleetManagment.ReadAPI.Dtos;
using FleetManagment.ReadAPI.Mappers;

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
            var requests = await _mediator.Send(new GetRequestsByDriverIdQuery(id));
            List<RequestDto> requestDtos = new List<RequestDto>();
            var mapper = new Mapper();

            foreach(var request in requests)
            {
                requestDtos.Add(mapper.toDto(request));
            }

            return Json(requestDtos);
        }

    }
}
