using FleetManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RequestController : Controller
    {
    
        [HttpPost]
        public Task<Request> AddRequest(Request request)
        {
            throw new NotImplementedException();
        }

    }
}
