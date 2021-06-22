using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.ReadModels;

namespace FleetManagement.ReadAPI.Queries
{
    public class GetDriverByIdQuery : IRequest<DriverDto>
    {
        public int Id { get; private set; }
        public GetDriverByIdQuery(int id)
        {
            Id = id;
            
        }
    }
}
