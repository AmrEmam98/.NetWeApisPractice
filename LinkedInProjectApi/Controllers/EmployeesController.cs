using LinkedInProjectApi.Dtos;
using LinkedInProjectApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkedInProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
           return Ok( await _context.Employees.ToListAsync());
        }
        [HttpPost]
        public  async Task<IActionResult> AddEmployee(EmployeeDto EmpDto)
        {
            EmployeeModel EmpModel = new EmployeeModel
            {
                Name = EmpDto.Name,
                Title = EmpDto.Title,
            };
            await _context.Employees.AddAsync(EmpModel);
             _context.SaveChanges();
            return Ok(EmpModel);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> UpdateEmployee(int Id, EmployeeDto employeeDto)
        {
            EmployeeModel Employee= await GetEmployeeById(Id);
            if (Employee == null)
                return NotFound("Employee Not found");
           Employee.Name= employeeDto.Name;
           Employee.Title= employeeDto.Title;
            _context.Employees.Update(Employee);
            _context.SaveChanges();
            return Ok(Employee);
        }
       private async Task<EmployeeModel> GetEmployeeById(int Id)=>await _context.Employees.SingleAsync(e=>e.Id==Id);
    }
}
