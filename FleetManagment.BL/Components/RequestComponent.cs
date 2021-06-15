using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.BL.Components
{
    public class RequestComponent : IRequestComponent
    {

        private readonly RequestRepository _requestRepository;

        public RequestComponent()
        {
            _requestRepository = new RequestRepository(new ApplicationDbContext());
        }

        public Request AddRequest(Request request)
        {
            if (IsValid(request))
            {
                _requestRepository.Add(request);
                return request;
            }
            throw new ArgumentException("Request not valid!");
        }


        private bool IsValid(Request request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(request, context, results, true);
        }
    }
}
