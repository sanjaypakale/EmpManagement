using EmployeeManagement.Core.Services;
using EmployeeManagement.Data;
using EmployeeManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test.Services
{
    public class EmployeeServiceTest : InMemoryEmployeeContext
    {
        [Fact]
        public async Task WhenGetEmployeeReturnEmployee()
        {
            //Arrange
            
            var employeeService = new EmployeeServices(EmployeeContext);

            //Act

            var firstEmployee = await employeeService.GetEmployeeById(1);

            //Assert

            Assert.Equal("Sanjay", firstEmployee.FirstName);

        }
    }
}
