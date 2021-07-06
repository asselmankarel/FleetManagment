using FleetManagement.BL.Requests;
using FleetManagement.BL.Responses;
using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.BL.Components
{
    public interface IRequestComponent
    {
        public ICreateResponse Create(ICreateRequest createRequest);
    }
}
