using FleetManagment.WriteAPI.Models;
using MediatR;
using System;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddRequest : IRequest<Response>
    {
        public int DriverId { get; init; }
        public int RequestType { get; init; }
        public DateTime PrefDate1 { get; init; }
        public DateTime PrefDate2 { get; init; }

    }
}
