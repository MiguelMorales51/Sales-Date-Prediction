using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/Employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("getEmployees")]
    public async Task<IActionResult> getEmployees()
    {
        var result = await _employeeService.getEmployees();
        if (result == null)
            return NotFound();
        else if (result.Count == 0)
            return NotFound();

        return Ok(result);
    }
}