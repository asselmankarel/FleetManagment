using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Models;
using MediatR;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddRequestCommand : IRequest<Response>
    {
        public int DriverId { get; private set; }
        public int RequestType { get; private set; }
        public DateTime PrefDate1 { get; private set; }
        public DateTime PrefDate2 { get; private set; }

        public AddRequestCommand(int driverId, int requestType, DateTime prefDate1, DateTime prefDate2)
        {
            DriverId = driverId;
            RequestType = requestType;
            PrefDate1 = prefDate1;
            PrefDate2 = prefDate2;
        }
    }
}
