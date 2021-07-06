using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BL.Requests
{
    public interface ICreateRequest
    {
        int DriverId { get; init; }

        int RequestType { get; init; }

        DateTime PrefDate1 { get; init; }

        DateTime PrefDate2 { get; init; }
    }
}
