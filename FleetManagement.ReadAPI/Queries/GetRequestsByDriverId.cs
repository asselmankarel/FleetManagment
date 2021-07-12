using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetRequestsByDriverId : IRequest<List<RequestInfo>>
    {
        public int Id { get; private set; }

        public GetRequestsByDriverId(int driverId)
        {
            Id = driverId;
        }
    }
}
