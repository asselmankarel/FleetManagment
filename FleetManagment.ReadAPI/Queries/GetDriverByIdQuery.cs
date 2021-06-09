using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FleetManagment.Domain.Models;

namespace FleetManagment.ReadAPI.Queries
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
