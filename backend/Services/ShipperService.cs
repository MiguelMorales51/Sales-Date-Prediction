using backend.Data;
using backend.Models;

namespace backend.Services;

public class ShipperService : IShipperService
{
    private readonly DatabaseConnection _db;

    public ShipperService(DatabaseConnection db)
    {
        _db = db;
    }

    public async Task<List<ShippersDto>> getShippers()
    {
        string query = @"SELECT shipperid, companyname
            FROM Sales.Shippers";
        var result = await _db.Select<ShippersDto>(query);
        return result;
    }
}
