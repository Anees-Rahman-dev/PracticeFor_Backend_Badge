using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PracticeFor_B_Review.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var Employees = await _employeesService.GetAll();

            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> GetById(int id) //the ? means the employee might not exist. In that case, the method can return null.
        {
            var Employee = await _employeesService.GetById(id);

            if (Employee != null)

                return Ok(Employee);

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _employeesService.Add(employee);
            return Ok("Added employee to the SQL SERVER");
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee(int id,Employee employee)
        {
            var Updated = await _employeesService.Update(id,employee);

            if (Updated)
            {
                return Ok("Employee updated");
            }
            else
            {
                return NotFound("Employee not found");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var Deleted = await _employeesService.Delete(id);

            if (Deleted)
            {
                return Ok("Employee Deleted");
            }
            else
            {
                return NotFound("Employee not found");
            }
        }

    }
}
