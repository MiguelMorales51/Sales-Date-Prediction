using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getProducts")]
    public async Task<IActionResult> getProducts()
    {
        var result = await _productService.getProducts();
        if (result == null)
            return NotFound();
        else if (result.Count == 0)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("getProducts/{id}")]
    public async Task<IActionResult> getProduct(int id)
    {
        var result = await _productService.getProduct(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}