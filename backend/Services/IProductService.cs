using backend.Models;

namespace backend.Services;

public interface IProductService
{
    Task<List<ProductsDto>> getProducts();
    Task<ProductsDto> getProduct(int productid);
}