using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public class RequestRepository : GenericRepository<RequestRequest>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context) { }

        public List<RequestRequest> GetRequestsByDriverId(int id, int number)
        {
            var requests = _context.Requests
                .Where(r => r.Driver.Id == id)
                .Include(r => r.Vehicle)
                .Skip(_context.Requests.Count() - number - 1);

            return requests.OrderByDescending(r => r.Id).ToList();
        }

        public async Task<List<RequestRequest>> GetRequests()
        {
            var requests = await _context.Requests.Include(r => r.Driver)
                .Include(r => r.Vehicle)
                .ThenInclude(v => v.VehicleLicensePlates.Where(vlp => vlp.EndDate == null))
                .ThenInclude(vlp => vlp.LicensePlate)
                .OrderBy(r => r.CreatedAt)
                .OrderBy(r => r.Driver.FirstName)
                .ToListAsync();

            return requests;
        }
    }
}
