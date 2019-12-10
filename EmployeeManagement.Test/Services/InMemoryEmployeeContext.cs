using EmployeeManagement.Data;
using EmployeeManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EmployeeManagement.Test.Services
{
    public abstract class InMemoryEmployeeContext : IDisposable
    {
        public EmployeeContext EmployeeContext { get; private set; }

        protected InMemoryEmployeeContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(new Guid().ToString())
                .Options;

            EmployeeContext = new EmployeeContext(options);

            EmployeeContext.Employees.Add(new Employee { Id = 1, FirstName = "Sanjay", LastName = "Pakale", Address = "Action", EmployeeCode = "i706089" });
            EmployeeContext.Employees.Add(new Employee { Id = 2, FirstName = "Harsha", LastName = "Pakale", Address = "Chandur", EmployeeCode = "xxeexx2" });


            EmployeeContext.SaveChanges();
        }

        public void Dispose()
        {
            EmployeeContext?.Dispose();
        }
    }
}
