using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context) { }

        public List<Request> GetRequestsByDriverId(int id, int number)
        {
            var requests = _context.Requests
                .Where(r => r.Driver.Id == id)
                .Include(r => r.Vehicle)
                .Skip(_context.Requests.Count() - number - 1);

            return requests.OrderByDescending(r => r.Id).ToList();
        }

        public async Task<List<Request>> GetRequests()
        {
            var requests = await _context.Requests.Include(r => r.Driver)
                .Include(r => r.Vehicle)
                .ThenInclude(v => v.VehicleLicensePlates.Where(vlp => vlp.EndDate == null))
                .ThenInclude(vlp => vlp.LicensePlate)
                .ToListAsync();

            return requests;
        }
    }
}
