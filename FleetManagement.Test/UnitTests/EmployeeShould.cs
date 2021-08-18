using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FleetManagement.Domain.Models;
using Xunit;
using Xunit.Abstractions;

namespace FleetManagement.Test.UnitTests
{
    public class EmployeeShould
    {
        private readonly ITestOutputHelper _output;

        private readonly Employee _employee = new Employee()
        {
            FirstName = "John",
            LastName = "Smith",
            DateOfBirth = DateTime.Now.AddYears(-38),
            Email = "john@smith.com"
        };

        public EmployeeShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void HaveFullNameFirstNameSpaceLastName()
        {
            _output.WriteLine("Employee should have a FullName method the returns 'Firstname Lastname'");
            Assert.Equal("John Smith", _employee.FullName());
        }

        [Fact]
        public void HaveErrorWhenInvalidNationalIsuranceNumber()
        {
            _employee.NationalIdentificationNumber = "83040704164";

            _output.WriteLine("Employee should detect invalid National Insurance Number");
            var context = new ValidationContext(_employee);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(_employee, context, results, true);
            var ErrorMessages = new List<string>();
            results.ForEach(result => ErrorMessages.Add(result.ErrorMessage));

            Assert.False(success);
            Assert.Contains("Invalid National Insurance Number", ErrorMessages);
        }

        [Theory]
        [InlineData("830407041656")]
        [InlineData("8304070416566")]
        [InlineData("9223372036854775808")]
        public void HaveErrorWhenNationalIsuranceNumberIsToLong(string nin)
        {
            _employee.NationalIdentificationNumber = nin;

            _output.WriteLine("Employee should detect invalid National Insurance Number");
            var context = new ValidationContext(_employee);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(_employee, context, results, true);
            var ErrorMessages = new List<string>();
            results.ForEach(result => ErrorMessages.Add(result.ErrorMessage));

            Assert.False(success);
            Assert.Contains("Invalid National Insurance Number", ErrorMessages);
        }

        [Theory]
        [InlineData("8304070416")]
        [InlineData("830407041")]
        [InlineData("83040704")]
        public void HaveErrorWhenNationalIsuranceNumberIsToShort(string nin)
        {
            _employee.NationalIdentificationNumber = nin;

            _output.WriteLine("Employee should detect invalid National Insurance Number");
            var context = new ValidationContext(_employee);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(_employee, context, results, true);
            var ErrorMessages = new List<string>();
            results.ForEach(result => ErrorMessages.Add(result.ErrorMessage));

            Assert.False(success);
            Assert.Contains("Invalid National Insurance Number", ErrorMessages);
        }

        [Fact]
        public void ValidateNationalInsuranceNumberFromBefore2000()
        {
            _employee.NationalIdentificationNumber = "83040706541";

            _output.WriteLine("Employee should validate National Insurance Number from before 2000");
            var context = new ValidationContext(_employee);
            var results = new List<ValidationResult>();
            bool success = Validator.TryValidateObject(_employee, context, results, true);
            var ErrorMessages = new List<string>();
            results.ForEach(result => ErrorMessages.Add(result.ErrorMessage));

            Assert.True(success);
            Assert.DoesNotContain("Invalid National Insurance Number", ErrorMessages);
        }

        [Fact]
        public void ValidateNationalInsuranceNumberFrom2000AndLater()
        {
            _employee.NationalIdentificationNumber = "10012701503";

            _output.WriteLine("Employee should validate National Insurance Number starting from 2000 and later");
            var context = new ValidationContext(_employee);
            var results = new List<ValidationResult>();
            var success = Validator.TryValidateObject(_employee, context, results, true);
            var errorMessages = new List<string>();
            results.ForEach(result => errorMessages.Add(result.ErrorMessage));

            Assert.True(success);
            Assert.DoesNotContain("Invalid National Insurance Number", errorMessages);
        }
    }
}
