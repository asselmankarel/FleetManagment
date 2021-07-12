using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Validators
{
    class DateMustBeInTheFuture : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateTime = value as DateTime? ?? new DateTime();

            if (dateTime.Date > DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Date must be in the future";
        }
    }
}
