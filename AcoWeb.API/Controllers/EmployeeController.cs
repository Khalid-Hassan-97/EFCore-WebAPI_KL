using AcoWeb.API.DTOs;
using AcoWeb.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcoWeb.API.Controllers;

[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        _mapper = mapper;
    }

    [HttpGet()]
    public IActionResult GetEmployees()
    {
        var employees = _employeeRepository.GetEmployees();

        var employeeDtoList = _mapper.Map<List<GetEmployeeDto>>(employees);

        return Ok(employeeDtoList);
    }

    [HttpGet("{officeId}")]
    public IActionResult GetEmployees(Guid officeId)
    {
        var employees = _employeeRepository.GetEmployees(officeId);
        return Ok(employees);
    }
}

