using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FleetManagement.Domain.Models;

namespace FleetManagement.ReadAPI.Queries
{
    public class GetDriverByIdQuery : IRequest<Driver>
    {
        public int Id { get; set; }
        public GetDriverByIdQuery(int id)
        {
            Id = id;
            
        }
    }
}
