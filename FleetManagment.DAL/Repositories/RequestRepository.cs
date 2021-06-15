using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public class RequestRepository : GenericRepository<Request>
    {
        public RequestRepository(ApplicationDbContext context) : base (context) { }

        public List<Request> GetRequestsByDriverId(int id)
        {
            var driver = _context.Drivers.Find(id);
            var requests = _context.Requests.Where(r => r.Driver == driver).Include(r => r.Vehicle);

            return requests.ToList();
        }
    }
}
