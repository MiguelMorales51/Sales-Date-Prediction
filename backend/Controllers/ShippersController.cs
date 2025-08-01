using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/Shippers")]
public class ShippersController : ControllerBase
{
    private readonly IShipperService _shipperService;

    public ShippersController(IShipperService shipperService)
    {
        _shipperService = shipperService;
    }

    [HttpGet("getShippers")]
    public async Task<IActionResult> getShippers()
    {
        var result = await _shipperService.getShippers();
        if (result == null)
            return NotFound();
        else if (result.Count == 0)
            return NotFound();

        return Ok(result);
    }
}