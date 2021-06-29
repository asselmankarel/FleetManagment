using FleetManagement.Domain.Models;
using System;
using Xunit;

namespace FleetManagement.Test
{
    public class EmployeeShould
    {
        [Fact]
        public void HaveFullNameFirstNameSpaceLastName()
        {
            Employee sut = new Employee() { FirstName = "John", LastName = "Smith" };

            Assert.Equal("John Smith", sut.FullName());
        }
    }
}
