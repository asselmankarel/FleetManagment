using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Mappers
{
    public static class Mapper
    {
        public static Request FromDto(RequestDto requestDto)
        {
            Request request = new Request();
            request.RequestType = requestDto.Type;
            request.PrefDate1 = requestDto.PrefDate1;
            request.PrefDate2 = requestDto.PrefDate2;
            request.Driver = new Driver();
            request.Driver.Id = requestDto.driverId;

            return request;
        }
    }
}
