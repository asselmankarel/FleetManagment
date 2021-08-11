using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IRequestRepository : IGenericRepository<RequestRequest>
    {
        List<RequestRequest> GetRequestsByDriverId(int id, int number);

        Task<List<RequestRequest>> GetRequests();
    }
}