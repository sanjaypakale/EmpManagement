using EmployeeManagement.Core.Services;
using EmployeeManagement.Data.Models;
using EmployeeManagement.UI.Controllers;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test.UI.Controllers
{
    public class EmployeeControllerTest
    {
        [Fact]
        public async Task WhenGetEmployeeShouldReturnValidData()
        {
            //Arrange
            var mockEmployeeService = new Mock<IEmployeeServices>();
            mockEmployeeService.Setup(c => c.GetEmployeeById(1)).ReturnsAsync((EmployeeViewModel)new EmployeeViewModel { Id = 1, FirstName = "sanjay", LastName = "Pakale" });
            var controller = new EmployeeController(mockEmployeeService.Object);

            //Act
            //await is required as action method is a asynchrouns.
            var result = await controller.GetEmployee(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<EmployeeViewModel>(okResult.Value);

            Assert.Equal("sanjay", returnValue.FirstName);
        }

        [Fact]
        public async Task WhenGetEmployeeShouldReturnBadResult()
        {
            //Arrange
            var mockEmployeeService = new Mock<IEmployeeServices>();
            mockEmployeeService.Setup(c => c.GetEmployeeById(1)).ReturnsAsync((EmployeeViewModel)new EmployeeViewModel { Id = 1, FirstName = "sanjay", LastName = "Pakale" });
            var controller = new EmployeeController(mockEmployeeService.Object);

            //Act
            //await is required as action method is a asynchrouns.
            var result = await controller.GetEmployee(-1);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task WhenCreateShouldReturnOkResult()
        {
            //Arrange
            var mockEmployeeService = new Mock<IEmployeeServices>();
            mockEmployeeService.Setup(repo => repo.AddEmployee(It.IsAny<EmployeeViewModel>())).ReturnsAsync((Employee)new Employee { Id = 2, FirstName = "test" });
            var controller = new EmployeeController(mockEmployeeService.Object);

            //Act
            //await is required as action method is a asynchrouns.
            var result = await controller.Create(new EmployeeViewModel { });

            //Assert           
            Assert.IsType<OkObjectResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Employee>(okResult.Value);

            Assert.Equal("test", returnValue.FirstName);
        }

        [Fact]
        public async Task WhenCreateShouldReturnBadResult()
        {
            //Arrange
            var mockEmployeeService = new Mock<IEmployeeServices>();
            mockEmployeeService.Setup(repo => repo.AddEmployee(null)).ReturnsAsync((Employee)new Employee { Id = 2, FirstName = "test" });
            var controller = new EmployeeController(mockEmployeeService.Object);

            //Act
            //await is required as action method is a asynchrouns.
            var result = await controller.Create(new EmployeeViewModel { });

            //Assert           
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
