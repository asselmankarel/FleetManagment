using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FleetManagement.Domain.Validators
{
    public class NationalInsuranceNumberValidator : ValidationAttribute
    {
        private DateTime Date;
        public override bool IsValid(object value)
        {
            string nis = value as string;
        
            if (nis.Length != 11) return false;
            if (!long.TryParse(nis, out _)) return false;

            try
            {
                return ValidationSuccessful(nis); 
            }
            catch
            {
                return false;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return "Invalid National Insurance Number";
        }

        private bool ValidationSuccessful(string nis)
        {
            string date = nis.Substring(0, 6);
            string sequence = nis.Substring(6, 3);
            string check = nis.Substring(9, 2);

            if (!IsValidDateString(date)) return false;

            if (!IsValidCheckSum(date, sequence, check)) return false;

            return true;
        }

        private bool IsValidDateString(string date)
        {
            Date = DateTime.ParseExact(date, "yyMMdd", CultureInfo.InvariantCulture);
            if (Date.Year >= 1900 && Date.Year <= 2100)
                return true;

            return false;
        }

        private bool IsValidCheckSum(string date, string sequence, string check)
        {
            long number;
            if (long.TryParse($"{date}{sequence}", out number))
            {
                if (Date.Year >= 2000) number += 2000000000;
                if (97 - (number % 97) == long.Parse(check)) return true;
            } 

            return false;
        }
    }
}
