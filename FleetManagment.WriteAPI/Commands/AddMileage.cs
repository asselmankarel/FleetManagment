using FleetManagment.WriteAPI.Models;
using MediatR;
using System;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddMileage : IRequest<Response>
    {
        public int VehicleId { get; private set; }
        public int Mileage { get; private set; }

        public DateTime Date { get; private set; }

        public AddMileage(int vehicleId, int mileage, DateTime date)
        {
            VehicleId = vehicleId;
            Mileage = mileage;
            Date = date;

        }
    }
}
