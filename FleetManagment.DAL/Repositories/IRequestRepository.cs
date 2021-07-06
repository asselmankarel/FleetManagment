using FleetManagement.Domain.Models;
using System.Collections.Generic;

namespace FleetManagement.DAL.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        List<Request> GetRequestsByDriverId(int id, int number);
    }
}