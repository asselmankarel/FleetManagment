using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.BL.Components
{
    public interface IRequestComponent
    {
        public bool AddRequest(int driverId, int requestType, DateTime prefDate1, DateTime prefDate2);
    }
}
