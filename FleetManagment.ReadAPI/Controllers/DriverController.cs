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
        private IMediator _mediatr;

       
        public DriverController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        // GET: /GetDriver/2
        [HttpGet]
        public async Task<DriverDto> GetDriver(int id)
        {
            var result = new Mapper().ToDto(await _mediatr.Send(new GetDriverByIdQuery(id)));
           
            return  result;
        }

        [HttpGet]
        public async Task<VehicleDto> GetDriverVehicle(int driverId)
        {
            var result = new Mapper().ToDto(await _mediatr.Send(new GetVehicleByDriverIdQuery(driverId)));

            return result;
        }


    }
}
