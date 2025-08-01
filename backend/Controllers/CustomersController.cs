using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/Customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("salesDatePredictionAsync")]
    public async Task<IActionResult> salesDatePredictionAsync()
    {
        var result = await _customerService.salesDatePredictionAsync();
        if (result == null)
            return NotFound();
        else if (result.Count == 0)
            return NotFound();

        return Ok(result);
    }
}