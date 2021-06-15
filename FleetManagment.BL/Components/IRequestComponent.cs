using FleetManagement.Domain.Models;

namespace FleetManagement.BL.Components
{
    public interface IRequestComponent
    {
        public Request AddRequest(Request request);
    }
}
