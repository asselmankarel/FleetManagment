using FleetManagement.Domain.Models;
using FluentValidation;

namespace FleetManagement.BL.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.Vin).MinimumLength(15).MinimumLength(17);

        }
    }
}
