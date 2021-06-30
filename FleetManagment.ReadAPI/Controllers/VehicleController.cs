using Microsoft.AspNetCore.Mvc;

namespace FleetManagment.ReadAPI.Controllers
{
    [ApiController]
    public class VehicleController : Controller
    {

        [HttpGet]
        [Route("[controller]/{vehicleId}/[action]")]
        public IActionResult Maintenances(int vehicleId)
        {
            return Json($"Maintenances for Vehicle Id = {vehicleId}");
        }

        [HttpGet]
        [Route("[controller]/{vehicleId}/[action]")]
        public IActionResult Repairs(int vehicleId)
        {
            return Json($"Repairs for Vehicle Id = {vehicleId}");
        }
    }
}
