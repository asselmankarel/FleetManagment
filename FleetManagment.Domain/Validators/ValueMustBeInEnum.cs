using FleetManagement.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Validators
{
    class ValueMustBeInEnum : ValidationAttribute
    {
        public Type _enumType { get; private set; }

        public ValueMustBeInEnum(Type enumType)
        {
            _enumType = enumType;
        }

        public override bool IsValid(object value)
        {
            var val = (int)value;

            return Enum.IsDefined(_enumType, val) ? true : false;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Type Value not valid";
        }
    }
}
