using backend.Data;
using backend.Models;

namespace backend.Services;

public class ProductService : IProductService
{
    private readonly DatabaseConnection _db;

    public ProductService(DatabaseConnection db)
    {
        _db = db;
    }

    public async Task<List<ProductsDto>> getProducts()
    {
        string query = @"SELECT productid, productname
            FROM Production.Products";
        var result = await _db.Select<ProductsDto>(query);
        return result;
    }

    public async Task<ProductsDto?> getProduct(int productid)
    {
        Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
        string query = @"SELECT productid, productname, unitprice
            FROM Production.Products
            WHERE productid = @productid";
        dic.Add("@productid", productid);
        var result = await _db.Select<ProductsDto>(query, dic);
        if (result == null)
            return null;
        else if (result.Count == 0)
            return null;
        return result[0];
    }
}
