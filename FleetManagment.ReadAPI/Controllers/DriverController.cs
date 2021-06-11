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

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var mapper = new DriverMapper();
            var result = mapper.ToDto(await _mediatr.Send(new GetDriverByIdQuery(id)));
           
            return  result;
        }



    }
}
