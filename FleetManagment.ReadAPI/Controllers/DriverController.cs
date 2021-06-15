using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FleetManagement.Domain.Models;
using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.Mappers;
using FleetManagment.ReadAPI.Dtos;
using FleetManagment.ReadAPI.Queries;

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : Controller
    {
        private IMediator _mediator;
       
        public DriverController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DriverDto> Driver(int id)
        {
            var result = new Mapper().ToDto(await _mediator.Send(new GetDriverByIdQuery(id)));
           
            return  result;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<VehicleDto> DriverVehicle(int id)
        {
            var result = new Mapper().ToDto(await _mediator.Send(new GetVehicleByDriverIdQuery(id)));

            return result;
        }

    }
}
