﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FleetManagment.Domain.Models;
using FleetManagment.Domain.Queries;


namespace FleetManagment.Domain.Handlers
{
    public class GetDriverByIdHandler : IRequestHandler<GetDriverByIdQuery, Driver>
    {
        

        public GetDriverByIdHandler()
        {
            
        }
        public Task<Driver> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
