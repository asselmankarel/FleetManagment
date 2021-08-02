using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        List<Request> GetRequestsByDriverId(int id, int number);

        Task<List<Request>> GetRequests();
    }
}