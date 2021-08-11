using FleetManagement.BL.Requests;
using FleetManagement.BL.Responses;
using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BL.Components
{
    public interface IRequestComponent
    {
        public ICreateResponse Create(ICreateRequest createRequest);

        public Task<List<RequestRequest>> GetRequests();
    }
}
