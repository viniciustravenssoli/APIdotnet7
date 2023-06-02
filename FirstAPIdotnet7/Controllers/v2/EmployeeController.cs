using AutoMapper;
using FirstAPIdotnet7.Application.ViewModel;
using FirstAPIdotnet7.Domain.DTOs;
using FirstAPIdotnet7.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstAPIdotnet7.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("2.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper = null)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeViewModel)
        {
            var filePath = Path.Combine("Storage", employeeViewModel.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeViewModel.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, filePath);
            
            _employeeRepository.Add(employee);

            return Ok();  
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Error, "Error");

            throw new Exception("Erro de Teste");

            var employees = _employeeRepository.Get(pageNumber, pageQuantity);

            _logger.LogInformation("teste");

            return Ok(employees);
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {

            var employeer = _employeeRepository.Get(id);

            var employeerDTO = _mapper.Map<EmployeeDTO>(employeer);

            _logger.LogInformation("teste");

            return Ok(employeerDTO);
        }
    }
}
