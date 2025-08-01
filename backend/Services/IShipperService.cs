using backend.Models;

namespace backend.Services;

public interface IShipperService
{
    Task<List<ShippersDto>> getShippers();
}