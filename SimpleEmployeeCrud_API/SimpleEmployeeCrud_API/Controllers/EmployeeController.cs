using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleEmployeeCrud_API.Models;
using SimpleEmployeeCrud_API.Services;

namespace SimpleEmployeeCrud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => EmployeeService.GetAll();
        [HttpGet("{Id}")]
        public ActionResult<Employee> Get(int Id)
        {
            var employee = EmployeeService.Get(Id);
            if (employee is null)
                return NotFound();
            return employee;
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            EmployeeService.Add(emp);
            return CreatedAtAction(nameof(Create), new { Id = emp.Id }, emp);
        }
        [HttpPut("{Id}")]
        public ActionResult Update(int Id, Employee emp)
        {
            if (Id != emp.Id)
                return BadRequest();

            var existEmployee = EmployeeService.Get(Id);
            if (existEmployee is null)
                return NotFound();


            EmployeeService.Update(emp);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var employee = EmployeeService.Get(Id);
            if (employee is null)
                return NotFound();
            EmployeeService.Delete(Id);
            return NoContent();
        }



    }
}
