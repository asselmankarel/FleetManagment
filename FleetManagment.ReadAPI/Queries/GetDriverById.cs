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
    public class GetDriverById : IRequest<DriverInfo>
    {
        public int Id { get; private set; }
        public GetDriverById(int id)
        {
            Id = id;
            
        }
    }
}
