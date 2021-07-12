using FleetManagement.Domain.Models;

namespace FleetManagement.BL.Components
{
    public interface IDriverComponent
    {
        Driver GetDriverById(int id);
    }
}