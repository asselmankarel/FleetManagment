using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FleetManagement.Domain.Models;
using FleetManagement.ReadAPI.Queries;

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
        public async Task<Driver> GetDriver(int id)
        {
            // var result =  _mediatr.Send(new GetDriverByIdQuery(id));
            // return await result;
            var driver = Task.Run(() => new Driver() {
                FirstName = "Karel",
                LastName = "Asselman",
                DriversLicense = DriversLicense.B });
            return await driver;
        }



    }
}
