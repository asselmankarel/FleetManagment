﻿using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.ReadModels;
using FleetManagment.ReadAPI.Mappers;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FleetManagement.DAL.DataAccess;

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;
       
        public DriverController(IMediator mediatr, IMapper mapper)
        {
            _mediator = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DriverInfo>> Show(int id)
        {
            var result = await _mediator.Send(new GetDriverById(id));
           
            return  Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VehicleInfo>> Vehicle(int id)
        {
            var vehicelInfo = await _mediator.Send(new GetVehicleByDriverId(id));

            return Ok(vehicelInfo);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FuelcardDto>> Fuelcard(int id)
        {
            var fuelcard = _mapper.ToDto(await _mediator.Send(new GetFuelcardByDriverIdQuery(id)));
        
            return Ok(fuelcard);
        }

    }
}
