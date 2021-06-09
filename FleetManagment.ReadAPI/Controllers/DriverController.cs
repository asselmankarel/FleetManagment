using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FleetManagment.Domain.Models;
using FleetManagment.ReadAPI.Queries;

namespace FleetManagment.ReadAPI.Controllers
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
        public async Task<Driver> GetDriver(int id)
        {
            var driver = new Driver() { FirstName = "Karel", LastName = "Asselman", DriversLicense = "B" };
            // var result =  _mediatr.Send(new GetDriverByIdQuery(id));
            // return await result;
            return driver;
        }



    }
}
