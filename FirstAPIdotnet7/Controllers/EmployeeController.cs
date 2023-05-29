using FirstAPIdotnet7.Model;
using FirstAPIdotnet7.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstAPIdotnet7.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeViewModel)
        {
            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, null);
            
            _employeeRepository.Add(employee);

            return Ok();  
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.Get();

            return Ok(employees);
        }
    }
}
