using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/Orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("getClientOrders/{id}")]
    public async Task<IActionResult> getClientOrders(int id)
    {
        var result = await _orderService.getClientOrders(id);
        if (result == null)
            return NotFound();
        else if (result.Count == 0)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("addNewOrder")]
    public async Task<IActionResult> addNewOrder([FromBody] SaveOrderDto order)
    {
        var result = await _orderService.addNewOrder(order);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}