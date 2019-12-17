using System.Threading.Tasks;
using EmployeeManagement.Core.Services;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _employeeServices.GetEmployeeById(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            var employee = await _employeeServices.AddEmployee(employeeViewModel);
            if (employee != null)
                return Ok(employee);

            return BadRequest();
        }
    }
}