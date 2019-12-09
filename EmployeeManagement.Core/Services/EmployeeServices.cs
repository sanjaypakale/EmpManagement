using EmployeeManagement.Data;
using EmployeeManagement.Data.Models;
using EmployeeManagement.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public interface IEmployeeServices
    {
        Task<EmployeeViewModel> GetEmployeeById(int id);
        Task<Employee> AddEmployee(EmployeeViewModel employeeViewModel);
        void DeleteEmployee(EmployeeViewModel employeeViewModel);

    }
    public class EmployeeServices : IEmployeeServices
    {
        private readonly EmployeeContext _context;
        public EmployeeServices(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeModel = new Employee
            {
                Id = employeeViewModel.Id,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Address = employeeViewModel.Address,
                EmployeeCode = employeeViewModel.EmployeeCode
            };

            _context.Employees.Add(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public void DeleteEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeModel = new Employee
            {
                Id = employeeViewModel.Id,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Address = employeeViewModel.Address,
                EmployeeCode = employeeViewModel.EmployeeCode
            };
            _context.Employees.Remove(employeeModel);
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
            return new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                EmployeeCode = employee.EmployeeCode
            };
        }
    }
}
