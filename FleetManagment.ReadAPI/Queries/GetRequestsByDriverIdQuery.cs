using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using MediatR;

namespace FleetManagment.ReadAPI.Queries
{
    public class GetRequestsByDriverIdQuery : IRequest<List<Request>>
    {
        public int Id { get; set; }

        public GetRequestsByDriverIdQuery(int driverId)
        {
            Id = driverId;
        }
    }
}
